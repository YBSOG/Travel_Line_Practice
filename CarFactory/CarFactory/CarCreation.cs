using CarFactory.Models.Body;
using CarFactory.Models.Brand;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.Transmission;
using CarFactory.Models.Car;
using CarFactory.Validation;

namespace CarFactory.CarFactory;
public class CarCreation
{
    public static Car CreateCar()
    {
        Car car = new Car(
            GetCarName(),
            GetCarBody(),
            GetCarBrand(),
            GetCarColor(),
            GetCarEngine(),
            GetCarTransmission()
            );
        return car;
    }

    public static string GetCarName()
    {
        Console.WriteLine( "Дайте название автомобилю:" );
        string carName = UserInputValidation.GetValidStringInput( Console.ReadLine() );
        return carName;
    }

    public static IBody GetCarBody()
    {
        Console.WriteLine( "Выберете кузов: 1 - Купе, 2 - Седан, 3 - Кроссовер." );

        int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

        switch ( userInput )
        {
            case 1:
                return new Coupe();
            case 2:
                return new Sedan();
            case 3:
                return new Сrossover();
            default:
                Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                return GetCarBody();
        }
    }

    public static IBrand GetCarBrand()
    {
        Console.WriteLine( "Выберете марку: 1 - Ауди, 2 - БМВ, 3 - Мерседес." );

        int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

        switch ( userInput )
        {
            case 1:
                return new Audi();
            case 2:
                return new BMW();
            case 3:
                return new Mercedes();
            default:
                Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                return GetCarBrand();
        }
    }

    public static IColor GetCarColor()
    {
        Console.WriteLine( "Выберете цвет: 1 - Черный, 2 - Синий, 3 - Белый." );

        int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

        switch ( userInput )
        {
            case 1:
                return new Black();
            case 2:
                return new Blue();
            case 3:
                return new White();
            default:
                Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                return GetCarColor();
        }
    }

    public static IEngine GetCarEngine()
    {
        Console.WriteLine( "Выберете двигатель: 1 - Атмосферный, 2 - Дизельный, 3 - Турбированный." );

        int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

        switch ( userInput )
        {
            case 1:
                return new Atmospheric();
            case 2:
                return new Diesel();
            case 3:
                return new Turbo();
            default:
                Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                return GetCarEngine();
        }
    }

    public static ITransmission GetCarTransmission()
    {
        Console.WriteLine( "Выберете коробку передач: 1 - Автомат, 2 - Механика, 3 - Робот." );

        int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

        switch ( userInput )
        {
            case 1:
                return new Auto();
            case 2:
                return new Manual();
            case 3:
                return new Robot();
            default:
                Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                return GetCarTransmission();
        }
    }
}
