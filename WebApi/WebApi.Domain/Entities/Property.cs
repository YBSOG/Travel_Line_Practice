namespace WebApi.Domain.Entities;
public class Property
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public List<RoomType> RoomTypes { get; set; } = new();
    public List<Reservation> Reservations { get; set; } = new();
}
