namespace CarFactory.Models.Transmission;
public interface ITransmission : IModel
{
    public int GearsCount { get; }
}