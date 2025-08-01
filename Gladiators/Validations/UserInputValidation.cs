namespace Gladiators.Validation
{
    public class UserInputValidation
    {
        public static string GetValidStringInput( string userStringInput )
        {
            while ( IsStringInputValid( userStringInput ) )
            {
                Console.WriteLine( "Введенное значение не подходит, попробуйте снова:" );
                userStringInput = Console.ReadLine();
            }

            return userStringInput;
        }
        private static bool IsStringInputValid( string userStringInput )
        {
            return string.IsNullOrWhiteSpace( userStringInput );
        }

        public static int GetValidIntInput( string userIntInput )
        {
            while ( !IsIntInputValid( userIntInput ) )
            {
                Console.WriteLine( "Введенное значение не подходит, попробуйте снова:" );
                userIntInput = Console.ReadLine();
            }
            int.TryParse( userIntInput, out int result );
            return result;
        }

        private static bool IsIntInputValid( string userIntInput )
        {
            return int.TryParse( userIntInput, out int result );
        }
    }
}
