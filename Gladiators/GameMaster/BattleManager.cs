using Gladiators.Models.Fighter;

namespace Gladiators.GameMaster
{
    public static class BattleManager
    {
        public static void Battle( List<Fighter> _fighters )
        {
            Console.WriteLine( "Бой" );

            _fighters = SortFightersByInitiative( _fighters );

            Fighter attacker = _fighters[ 0 ];
            Fighter defender = _fighters[ 1 ];

            int attackerHp = attacker.FighterStatus.MaxHealth;
            int defenderHp = defender.FighterStatus.MaxHealth;

            for ( int i = 1; i <= 20; i++ )
            {
                Console.WriteLine();
                Console.WriteLine( $"Раунд: {i}" );

                int attackerDamage = attacker.CalculateAttackDamage();
                defenderHp = defender.TakeDamage( attackerDamage, defenderHp );
                Console.WriteLine( $"{attacker.Name} наносит {attackerDamage}, у {defender.Name} остается {defenderHp} хп." );
                if ( defenderHp == 0 )
                {
                    Console.WriteLine( $"{attacker.Name} наносит смертельный удар по {defender.Name} и становится победителем!" );
                    break;
                }

                int defenderDamage = defender.CalculateAttackDamage();
                attackerHp = attacker.TakeDamage( defenderDamage, attackerHp );
                Console.WriteLine( $"{defender.Name} наносит {defenderDamage}, у {attacker.Name} остается {attackerHp} хп." );
                if ( attackerHp == 0 )
                {
                    Console.WriteLine( $"{defender.Name} наносит смертельный удар по {attacker.Name} и становится победителем!" );
                    break;
                }

                if ( i == 20 )
                {
                    Console.WriteLine( "Бой затянулся, придестя его остановить..." );
                    break;
                }
            }
        }

        private static List<Fighter> SortFightersByInitiative( List<Fighter> _fighters )
        {
            _fighters = _fighters.OrderByDescending( _fighters => _fighters.FighterStatus.Initiative ).ToList();
            Fighter attacker = _fighters[ 0 ];
            Fighter defender = _fighters[ 1 ];

            Console.WriteLine( $"Инициатива бойцов: {attacker.Name} - {attacker.FighterStatus.Initiative}, {defender.Name} - {defender.FighterStatus.Initiative}." );
            Console.WriteLine( $"{attacker.Name} атакует первым." );

            return _fighters;
        }
    }
}
