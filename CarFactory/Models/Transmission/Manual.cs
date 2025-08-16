namespace CarFactory.Models.Transmission;
public class Manual : ITransmission
{
    public string Name => "Механическая";

    public int GearsCount => 5;
}