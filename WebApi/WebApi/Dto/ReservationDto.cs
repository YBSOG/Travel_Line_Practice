namespace WebApi.Dto
{
    public class ReservationResponseDto
    {
        public int Id { get; set; }
        public PropertyResponseDto Property { get; set; } = null!;
        public RoomTypeResponseDto RoomType { get; set; } = null!;
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public string GuestPhoneNumber { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string Currency { get; set; } = "USD";
        public bool IsCancelled { get; set; }
    }

    public class ReservationCreateDto
    {
        public int PropertyId { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public string GuestPhoneNumber { get; set; } = string.Empty;
    }

    public class SearchRequestDto
    {
        public string? City { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PersonCount { get; set; }
        public decimal? MaxPrice { get; set; }
    }

    public class SearchResultDto
    {
        public PropertyResponseDto Property { get; set; } = null!;
        public RoomTypeResponseDto RoomType { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public decimal Total { get; set; }
    }
}
