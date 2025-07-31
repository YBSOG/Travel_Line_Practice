using Gladiators.Models.Armor;
using Gladiators.Models.Class;
using Gladiators.Models.Race;
using Gladiators.Models.Weapon;
using Gladiators.Models.Fighter;
using Gladiators.Validation;


namespace Gladiators.GameMaster
{
    public class CharacterCtreation
    {
        public static Fighter CreateFighter()
        {
            Fighter fighter = new Fighter(
                GetFighterName(),
                GetFighterClass(),
                GetFighterRace(),
                GetFighterWeapon(),
                GetFighterArmor()
            );
            return fighter;
        }

        private static string GetFighterName()
        {
            Console.WriteLine( "Дайте бойцу имя:" );
            string fighterName = UserInputValidation.GetValidStringInput( Console.ReadLine() );
            return fighterName;
        }

        private static IRace GetFighterRace()
        {
            Console.WriteLine( $"Выберите расу бойца: 1 - Дворф, 2 - Человек, 3 - Орк." );

            int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

            switch ( userInput )
            {
                case 1:
                    return new DwarfRace();
                case 2:
                    return new HumanRace();
                case 3:
                    return new OrcRace();
                default:
                    Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                    return GetFighterRace();
            }
        }

        private static IClass GetFighterClass()
        {
            Console.WriteLine( "Выберите класс бойца: 1 - Варвар, 2 - Рыцарь, 3 - Монах." );

            int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

            switch ( userInput )
            {
                case 1:
                    return new BarbarianClass();
                case 2:
                    return new KnightClass();
                case 3:
                    return new MoncClass();
                default:
                    Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                    return GetFighterClass();
            }
        }

        private static IWeapon GetFighterWeapon()
        {
            Console.WriteLine( "Выберите оружие бойца: 1 - Топор, 2 - Кулаки, 3 - Меч." );

            int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

            switch ( userInput )
            {
                case 1:
                    return new AxeWeapon();
                case 2:
                    return new FistsWeapon();
                case 3:
                    return new SwordWeapon();
                default:
                    Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                    return GetFighterWeapon();
            }
        }

        private static IArmor GetFighterArmor()
        {
            Console.WriteLine( "Выберите броню бойца: 1 - Железная броня, 2 - Кожанная броня, 3 - Без брони." );

            int userInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

            switch ( userInput )
            {
                case 1:
                    return new IronArmor();
                case 2:
                    return new LeatherArmor();
                case 3:
                    return new NoArmor();
                default:
                    Console.WriteLine( "Введенное значение не походит, попробуйте снова:" );
                    return GetFighterArmor();
            }
        }
    }
}
