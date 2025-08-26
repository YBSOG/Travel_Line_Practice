namespace WebApi.Domain.Entities;
public class Reservation
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public string GuestName { get; set; } = string.Empty;
    public string GuestPhoneNumber { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string Currency { get; set; } = "USD";
    public bool IsCancelled { get; set; }

    public Property Property { get; set; } = null!;
    public RoomType RoomType { get; set; } = null!;
}