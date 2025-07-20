using HW2_Casino;

const string gameName = @"
     ######     ##      ######  ######  ##      ##   #####  
    ##        ##  ##   ##         ##    ###     ##  ##   ## 
    ##       ##    ##  ##         ##    ## ##   ##  ##   ## 
    ##       ########   ######    ##    ##  ##  ##  ##   ## 
    ##       ##    ##        ##   ##    ##   ## ##  ##   ## 
    ##       ##    ##        ##   ##    ##     ###  ##   ## 
     ######  ##    ##   ######  ######  ##      ##   #####  
    ";
double balance = 0;
const double multiplicator = 0.1;
Random rand = new Random();

PrintGameName( gameName );
balance = Deposit();
Menu();

void Menu()
{
    Console.WriteLine( "=МЕНЮ=" );
    Console.WriteLine( "Навигация: 1 - Играть. 2 - Проверить баланс. 3 - Выход из игры." );
    HandleOperation( ( Operation )ReadOperation() );
}

static Operation? ReadOperation()
{
    string operationStr = Console.ReadLine();
    bool isParsed = Enum.TryParse( operationStr, out Operation operation );
    if ( isParsed )
    {
        return operation;
    }
    else
    {
        Console.WriteLine( "Недопустимое значение, попробуйте заново:" );
        return ReadOperation();
    }
}

void HandleOperation( Operation operation )
{
    switch ( operation )
    {
        case Operation.Play:
            balance = Spin( balance );
            Menu();
            break;

        case Operation.CheckBalance:
            Console.WriteLine( $"Баланс: {balance}" );
            Menu();
            break;

        case Operation.Exit:
            break;

        default:
            Console.WriteLine( "Недопустимое значение, попробуйте заново:" );
            HandleOperation( ( Operation )ReadOperation() );
            break;
    }
}

static void PrintGameName( string gameName )
{
    Console.WriteLine( gameName );
    Console.WriteLine();
}

double Deposit()
{
    balance = UserStringToDouble( "Внесите депозит(от 1 до 1000):" );
    if ( balance >= 1 && balance <= 1000 )
    {
        Console.WriteLine( $"Ваш баланс: {balance}" );
        return balance;
    }
    else
    {
        Console.WriteLine( "Недопустимое значение, попробуйте еще раз:" );
        Console.WriteLine();
        return Deposit();
    }
}

double Spin( double balance )
{
    ValidateBalance( balance );

    double bet = UserStringToDouble( $"Сделайте ставку (от 1 до 500):" );
    if ( bet <= balance && bet >= 1 && bet <= 500 )
    {
        int randomNumber = rand.Next( 0, 21 );
        if ( randomNumber == 18 || randomNumber == 19 || randomNumber == 20 )
        {
            double profit = bet * ( 1 + multiplicator * ( randomNumber % 17 ) );
            balance += profit;
            Console.WriteLine( $"Победа! ваш выигры: {profit}" );
            return balance;
        }
        else
        {
            balance -= bet;
            Console.WriteLine( "Проигрыш..." );
            return balance;
        }
    }
    else
    {
        Console.WriteLine( "Недопустимое значение ставки, попробуйте еще раз:" );
        return Spin( balance );
    }
}

void ValidateBalance( double balance )
{
    if ( balance < 1 )
    {
        double userAnswer = UserStringToDouble( "Недостаточный баланс. 1 - Внести депозит. 2 - Выйти из игры." );
        switch ( userAnswer )
        {
            case 1:
                Deposit();
                Menu();
                break;
            case 2:
                HandleOperation( Operation.Exit );
                break;
            default:
                Console.WriteLine( "Недопустимое значение, попробуйте еще раз:" );
                ValidateBalance( balance );
                break;
        }
    }
    else return;
}

double UserStringToDouble( string message )
{
    Console.WriteLine( message );
    string userString = Console.ReadLine();
    bool isStringParsed = double.TryParse( userString, out double value );
    if ( isStringParsed )
    {
        return value;
    }
    else
    {
        Console.WriteLine( "Недопустимое значение, попробуйте еще раз:" );
        return UserStringToDouble( message );
    }
}