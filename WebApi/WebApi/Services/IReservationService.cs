using WebApi.Dto;

namespace WebApi.Services
{
    public interface IReservationService
    {
        public Task<IEnumerable<SearchResultDto>> SearchAvailableRooms( SearchRequestDto searchRequest );

        public Task<ReservationResponseDto> CreateReservation( ReservationCreateDto reservationDto );

        public Task<bool> CancelReservation( int reservationId );
    }
}
