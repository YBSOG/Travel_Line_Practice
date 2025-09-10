namespace WebApi.Dto
{
    public class RoomTypeCreateDto
    {
        public int PropertyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public string Currency { get; set; } = "USD";
        public int MinPersonCount { get; set; }
        public int MaxPersonCount { get; set; }
        public List<string> Services { get; set; } = new();
        public List<string> Amenities { get; set; } = new();
    }

    public class RoomTypeResponseDto
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
    }
}
