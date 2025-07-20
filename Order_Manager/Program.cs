public class OrderManager
{
    public static void Main()
    {
        OrderCreation();
    }

    public static string CheckStringInput( string userStringInput )
    {
        if ( string.IsNullOrWhiteSpace( userStringInput ) )
        {
            Console.WriteLine( "Введенное значние не подходит, попробуйте ещё раз." );
            return CheckStringInput( Console.ReadLine() );
        }
        else
        {
            return userStringInput;
        }
    }

    public static void OrderCreation()
    {
        string name;
        string product;
        int count;
        string address;
        string answer;
        DateTime todays_date = DateTime.Now;

        Console.WriteLine( "Введите ваше имя:" );
        name = CheckStringInput( Console.ReadLine() );

        Console.WriteLine( "Введите наименования необходимого товара:" );
        product = CheckStringInput( Console.ReadLine() );

        Console.WriteLine( "Введите необходимое количество единиц товара (цифрой от 1 до 9):" );
        while ( true )
        {
            var countInput = Console.ReadLine();
            if ( int.TryParse( countInput, out int number ) )
            {
                if ( number > 0 && number < 10 )
                {
                    count = number;
                    break;
                }
                else
                {
                    Console.WriteLine( "Введенное значение не подходит, введите количество заново:" );
                }
            }
            else
            {
                Console.WriteLine( "Введенное значение не подходит, введите количество заново:" );
            }
        }

        Console.WriteLine( "Введите адрес, куда будет доставлен товар:" );
        address = CheckStringInput( Console.ReadLine() );


        Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}. Введите \"да\" для подтверждения заказа" );
        answer = Console.ReadLine();
        if ( answer == "да" )
        {
            Console.WriteLine();
            Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {todays_date.AddDays( 3 )}" );
        }
        else
        {
            Console.WriteLine( "Сформируем заказ заново." );
            Console.WriteLine();
            OrderManager.Main();
        }
    }
}