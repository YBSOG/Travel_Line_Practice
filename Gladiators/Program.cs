using Gladiators.Validation;
using Gladiators.Models.Fighter;
using Gladiators.GameMaster;

namespace Gladiators
{
    public class Program
    {
        private static readonly List<Fighter> _fighters = [];

        public static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine( "=Меню=" );
            Console.WriteLine( "Навигация: 1 - Создать бойцов. 2 - Сражение. 3 - Выход из игры." );

            int userCommandInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );

            switch ( userCommandInput )
            {
                case 1:
                    AddNewFighters( _fighters );
                    Menu();
                    break;

                case 2:
                    StartBattle( _fighters );
                    Menu();
                    break;
                case 3:
                    break;

                default:
                    Console.WriteLine( "Введено неверное значение, попробуйте снова:" );
                    Menu();
                    break;
            }
        }

        private static bool CheckIfFightersListIsEmpty( List<Fighter> _fighters )
        {
            if ( _fighters.Count == 0 )
            {
                return true;
            }
            else return false;
        }

        private static void AddNewFighters( List<Fighter> _fighters )
        {
            if ( CheckIfFightersListIsEmpty( _fighters ) )
            {
                Console.WriteLine( "Создайте первого бойца." );
                Fighter firstFighter = CharacterCtreation.CreateFighter();
                _fighters.Add( firstFighter );

                Console.WriteLine( "Создайте второго бойца" );
                Fighter secondFighter = CharacterCtreation.CreateFighter();
                _fighters.Add( secondFighter );

                ShowFightersInfo( _fighters );
            }
            else
            {
                Console.WriteLine( "Этим действием вы перезапишите созданных ранее бойцов:" );
                ShowFightersInfo( _fighters );
                Console.WriteLine( "Хотите продолжить? 1 - Да, 2 - Нет." );

                int userCommandInput = UserInputValidation.GetValidIntInput( Console.ReadLine() );
                switch ( userCommandInput )
                {
                    case 1:
                        _fighters.Clear();
                        AddNewFighters( _fighters );
                        break;

                    case 2:
                        break;

                    default:
                        Console.WriteLine( "Введено неверное значение, попробуйте снова:" );
                        AddNewFighters( _fighters );
                        break;
                }
            }
        }

        private static void ShowFightersInfo( List<Fighter> _fighters )
        {
            Fighter firstFighter = _fighters[ 0 ];
            Fighter secondFighter = _fighters[ 1 ];

            Console.WriteLine( $"Первый боец: Имя - {firstFighter.Name}, раса - {firstFighter.FighterCharacteristics.Race.Name}, класс - {firstFighter.FighterCharacteristics.Class.Name}, оружие - {firstFighter.FighterCharacteristics.Weapon.Name}, броня - {firstFighter.FighterCharacteristics.Armor.Name}" );
            Console.WriteLine( $"Второй боец: Имя - {secondFighter.Name}, раса - {secondFighter.FighterCharacteristics.Race.Name}, класс - {secondFighter.FighterCharacteristics.Class.Name}, оружие - {secondFighter.FighterCharacteristics.Weapon.Name}, броня - {secondFighter.FighterCharacteristics.Armor.Name}" );
        }

        private static void StartBattle( List<Fighter> _fighters )
        {
            if ( CheckIfFightersListIsEmpty( _fighters ) )
            {
                Console.WriteLine( "Вы еще не создали бойцов!" );
            }
            else
            {
                BattleManager.Battle( _fighters );
            }
        }
    }
}