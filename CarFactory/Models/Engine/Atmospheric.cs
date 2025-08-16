namespace CarFactory.Models.Engine;
public class Atmospheric : IEngine
{
    public string Name => "Атмосферный";

    public int MaxSpeed => 250;
}