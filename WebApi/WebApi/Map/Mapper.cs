using WebApi.Domain.Entities;
using WebApi.Dto;

namespace WebApi.Map
{
    public class Mapper
    {
        public static PropertyResponseDto MapToPropertyDto( Property property )
        {
            return new PropertyResponseDto
            {
                Id = property.Id,
                Name = property.Name,
                Country = property.Country,
                City = property.City,
                Address = property.Address,
                Latitude = property.Latitude,
                Longitude = property.Longitude,
                RoomTypes = property.RoomTypes.Select( MapToRoomTypeDto ).ToList()
            };
        }

        public static RoomTypeResponseDto MapToRoomTypeDto( RoomType roomType )
        {
            return new RoomTypeResponseDto
            {
                Id = roomType.Id,
                PropertyId = roomType.PropertyId,
                Name = roomType.Name,
                DailyPrice = roomType.DailyPrice,
                Currency = roomType.Currency,
                MinPersonCount = roomType.MinPersonCount,
                MaxPersonCount = roomType.MaxPersonCount,
                Services = roomType.Services,
                Amenities = roomType.Amenities
            };
        }

        public static ReservationResponseDto MapToReservationDto( Reservation reservation )
        {
            return new ReservationResponseDto
            {
                Id = reservation.Id,
                Property = MapToPropertyDto( reservation.Property ),
                RoomType = MapToRoomTypeDto( reservation.RoomType ),
                ArrivalDate = reservation.ArrivalDate,
                DepartureDate = reservation.DepartureDate,
                ArrivalTime = reservation.ArrivalTime,
                DepartureTime = reservation.DepartureTime,
                GuestName = reservation.GuestName,
                GuestPhoneNumber = reservation.GuestPhoneNumber,
                Total = reservation.Total,
                Currency = reservation.Currency,
                IsCancelled = reservation.IsCancelled
            };
        }
    }
}
