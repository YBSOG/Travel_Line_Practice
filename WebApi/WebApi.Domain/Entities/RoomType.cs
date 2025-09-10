namespace WebApi.Domain.Entities;
public class RoomType
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal DailyPrice { get; set; }
    public string Currency { get; set; } = "USD";
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public List<string> Services { get; set; } = new();
    public List<string> Amenities { get; set; } = new();
    public bool IsDeleted { get; set; } = false;

    public Property Property { get; set; } = null!;
    public List<Reservation> Reservations { get; set; } = new();
}
