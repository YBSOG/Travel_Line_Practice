using CarFactory.Models.Body;
using CarFactory.Models.Brand;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Car;
public interface ICar : IModel
{
    public IBody Body { get; }
    public IBrand Brand { get; }
    public IColor Color { get; }
    public IEngine Engine { get; }
    public ITransmission Transmission { get; }

}
