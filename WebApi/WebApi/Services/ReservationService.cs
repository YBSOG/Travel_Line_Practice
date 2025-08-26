using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Dto;
using WebApi.Map;

namespace WebApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(
            IPropertyRepository propertyRepository,
            IRoomTypeRepository roomTypeRepository,
            IReservationRepository reservationRepository )
        {
            _propertyRepository = propertyRepository;
            _roomTypeRepository = roomTypeRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<SearchResultDto>> SearchAvailableRooms( SearchRequestDto searchRequest )
        {
            IEnumerable<Property?>? properties = await _propertyRepository.Search(
                searchRequest.City,
                searchRequest.PersonCount,
                searchRequest.PersonCount,
                searchRequest.MaxPrice );

            List<SearchResultDto> searchResult = new List<SearchResultDto>();

            foreach ( Property property in properties )
            {
                foreach ( RoomType roomType in property.RoomTypes )
                {
                    if ( roomType.MinPersonCount <= searchRequest.PersonCount &&
                        roomType.MaxPersonCount >= searchRequest.PersonCount )
                    {
                        bool isAvailable = await _roomTypeRepository.IsRoomTypeAvailable(
                            roomType.Id,
                            searchRequest.ArrivalDate,
                            searchRequest.DepartureDate );
                        int days = ( searchRequest.DepartureDate - searchRequest.ArrivalDate ).Days;

                        decimal totalPrice = roomType.DailyPrice * days;

                        searchResult.Add( new SearchResultDto
                        {
                            Property = Mapper.MapToPropertyDto( property ),
                            RoomType = Mapper.MapToRoomTypeDto( roomType ),
                            IsAvailable = isAvailable,
                            Total = totalPrice
                        } );
                    }
                }
            }

            return searchResult;
        }

        public async Task<ReservationResponseDto> CreateReservation( ReservationCreateDto reservationDto )
        {
            bool isAvailable = await _roomTypeRepository.IsRoomTypeAvailable(
                reservationDto.RoomTypeId,
                reservationDto.ArrivalDate,
                reservationDto.DepartureDate );

            if ( !isAvailable ) throw new InvalidOperationException( "Room is not available for selected date" );

            RoomType? roomType = await _roomTypeRepository.GetById( reservationDto.RoomTypeId );

            if ( roomType is null ) throw new KeyNotFoundException( "Room type not found" );

            int days = ( reservationDto.DepartureDate - reservationDto.ArrivalDate ).Days;

            decimal totalPrice = roomType.DailyPrice * days;

            Reservation reservation = new Reservation
            {
                PropertyId = reservationDto.PropertyId,
                RoomTypeId = reservationDto.RoomTypeId,
                ArrivalDate = reservationDto.ArrivalDate,
                DepartureDate = reservationDto.DepartureDate,
                ArrivalTime = reservationDto.ArrivalTime,
                DepartureTime = reservationDto.ArrivalTime,
                GuestName = reservationDto.GuestName,
                GuestPhoneNumber = reservationDto.GuestPhoneNumber,
                Total = totalPrice,
                Currency = roomType.Currency,
                IsCancelled = false
            };

            await _reservationRepository.Create( reservation );

            return Mapper.MapToReservationDto( reservation );
        }

        public async Task<bool> CancelReservation( int reservationId )
        {
            Reservation? reservation = await _reservationRepository.GetById( reservationId );
            if ( reservation is null || reservation.IsCancelled ) return false;

            reservation.IsCancelled = true;
            await _reservationRepository.Update( reservation );
            return true;
        }
    }
}
