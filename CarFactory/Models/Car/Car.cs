using CarFactory.Models.Body;
using CarFactory.Models.Brand;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.Car;
public class Car : ICar
{
    public string Name { get; }
    public IBody Body { get; }
    public IBrand Brand { get; }
    public IColor Color { get; }
    public ITransmission Transmission { get; }
    public IEngine Engine { get; }
    public int GearsCount { get; }
    public int MaxSpeed { get; }
    public Car( string name, IBody body, IBrand brand, IColor color, IEngine engine, ITransmission transmission )
    {
        Name = name;
        Body = body;
        Brand = brand;
        Color = color;
        Engine = engine;
        Transmission = transmission;
        GearsCount = transmission.GearsCount;
        MaxSpeed = engine.MaxSpeed;
    }

    public string CarCharacteristics()
    {
        return
            $"Имя: {Name}." +
            $"Кузов: {Body.Name}." +
            $"Марка: {Brand.Name}." +
            $"Цвет: {Color.Name}." +
            $"Двигатель: {Engine}." +
            $"Коробка передач:{Transmission.Name}, Количество передач: {GearsCount}." +
            $"Максимальная скорость: {MaxSpeed}.";
    }
}
