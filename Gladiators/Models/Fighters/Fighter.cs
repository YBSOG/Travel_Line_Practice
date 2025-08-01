using Gladiators.Models.Class;
using Gladiators.Models.Race;
using Gladiators.Models.Weapon;
using Gladiators.Models.Armor;

namespace Gladiators.Models.Fighter
{
    public class Fighter : IFighter
    {
        public string Name { get; }
        public FighterStatus FighterStatus { get; }
        public FighterCharacteristics FighterCharacteristics { get; }

        public Fighter( string name, IClass @class, IRace race, IWeapon weapon, IArmor armor )
        {
            Name = name;

            FighterCharacteristics = new FighterCharacteristics( race, @class, armor, weapon );

            int maxHealth = race.Health + @class.Health;
            int fullArmor = race.Armor + armor.Armor;
            int maxDamage = race.Damage + @class.Damage + weapon.Damage;
            int initiative = race.Initiative + @class.Initiative + armor.Initiative + weapon.Initiative;

            FighterStatus = new FighterStatus( maxHealth, fullArmor, maxDamage, initiative );
        }

        public int TakeDamage( int damage, int currentHp )
        {
            int fullArmor = FighterStatus.FullArmor;

            currentHp = currentHp - ( damage - fullArmor );

            if ( currentHp <= 1 )
            {
                currentHp = 0;
            }

            return currentHp;
        }

        public int CalculateAttackDamage()
        {
            int maxDamage = FighterStatus.MaxDamage;

            Random random = new Random();

            int minDamagePercent = 80;
            int maxDamagePercent = 120;

            double damageMultiplicator = ( maxDamagePercent - random.NextDouble() * ( maxDamagePercent - minDamagePercent ) ) / 100;

            double damage = maxDamage * damageMultiplicator;

            int damageDealt = ( int )Math.Round( damage );

            damageDealt = CalculateCrit( damageDealt, random );

            return damageDealt;
        }

        private int CalculateCrit( int maxDamage, Random random )
        {
            int criticalMultiplicator = 2;
            double criticalChancePercent = 10;

            if ( random.Next( 100 ) <= criticalChancePercent )
            {
                maxDamage = maxDamage * criticalMultiplicator;
                Console.WriteLine( $"  {Name} наносит критический урон!" );
            }
            return maxDamage;
        }
    }
}