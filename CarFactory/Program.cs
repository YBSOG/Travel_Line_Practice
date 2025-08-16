using CarFactory.CarFactory;
using CarFactory.Models.Car;
using CarFactory.Validation;

namespace CarFactory;

public class Program
{
    public static void Main()
    {
        Console.WriteLine( "Конструктор вашего авто." );
        Menu();
    }

    public static void Menu()
    {
        Car car = CarCreation.CreateCar();

        Console.WriteLine( $"Имя: {car.Name}. " +
            $"Кузов: {car.Body.Name}. " +
            $"Марка: {car.Brand.Name}. " +
            $"Цвет: {car.Color.Name}. " +
            $"Двигатель: {car.Engine.Name}. " +
            $"Коробка передач: {car.Transmission.Name}, Количество передач: {car.GearsCount}. " +
            $"Максимальная скорость: {car.MaxSpeed} км/ч." );

        CreateAnotherCar();
    }

    public static void CreateAnotherCar()
    {
        Console.WriteLine( "" );
        Console.WriteLine( "Хотите попробовать снова? 1 -Да, 2 - Нет." );
        int userCommandInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );
        switch ( userCommandInput )
        {
            case 1:
                Main();
                break;
            case 2:
                break;
            default:
                Console.WriteLine( "Введено неверное значение, попробуйте снова:" );
                CreateAnotherCar();
                break;
        }
    }
}