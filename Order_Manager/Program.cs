Run();
void Run()
{
    OrderCreation();
}

string GetValidInput( string userStringInput )
{
    while ( IsInputValid( userStringInput ) )
    {
        Console.WriteLine( "Введенное значение не подходит, попробуйте снова" );
        userStringInput = Console.ReadLine();
    }

    return userStringInput;
}

bool IsInputValid( string userStringInput )
{
    return string.IsNullOrWhiteSpace( userStringInput );
}

string GetUserName()
{
    Console.WriteLine( "Введите ваше имя:" );
    string userName = GetValidInput( Console.ReadLine() );
    return userName;
}

string GetProductName()
{
    Console.WriteLine( "Введите наименования необходимого товара:" );
    string productName = GetValidInput( Console.ReadLine() );
    return productName;
}

string GetUserAddress()
{
    Console.WriteLine( "Введите адрес, куда будет доставлен товар:" );
    string userAddress = GetValidInput( Console.ReadLine() );
    return userAddress;
}

int GetCountOfProduct()
{
    int countOfProduct = 0;
    Console.WriteLine( "Введите необходимое количество единиц товара (цифрой от 1 до 9):" );

    bool countApproval = false;
    do
    {
        string userCountInput = Console.ReadLine();
        if ( int.TryParse( userCountInput, out int number ) )
        {
            if ( number > 0 && number < 10 )
            {
                countOfProduct = number;
                countApproval = true;
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
    } while ( !countApproval );

    return countOfProduct;
}

void OrderConfiramtion( string name, string product, int count, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}. Введите \"да\" для подтверждения заказа:" );

    string answer = Console.ReadLine();
    if ( answer == "да" )
    {
        DateTime todaysDate = DateTime.Now.ToUniversalTime();
        string orderArrivalDate = ( todaysDate.AddDays( 3 ) ).ToString( "dd/MM/yyyy" );
        Console.WriteLine();
        Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {orderArrivalDate}" );
    }
    else
    {
        Console.WriteLine( "Сформируем заказ заново." );
        Console.WriteLine();
        Run();
    }
}

void OrderCreation()
{
    string name = GetUserName();
    string product = GetProductName();
    int count = GetCountOfProduct();
    string address = GetUserAddress();

    OrderConfiramtion( name, product, count, address );
}