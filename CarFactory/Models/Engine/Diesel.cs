namespace CarFactory.Models.Engine;
internal class Diesel : IEngine
{
    public string Name => "Дизельный";

    public int MaxSpeed => 200;
}