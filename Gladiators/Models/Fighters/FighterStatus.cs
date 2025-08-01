namespace Gladiators.Models.Fighter
{
    //Тут данные для вычислений во время боя
    public class FighterStatus( int maxHealth, int fullArmor, int maxDamage, int initiative )
    {
        public int MaxHealth { get; } = maxHealth;
        public int FullArmor { get; } = fullArmor;
        public int MaxDamage { get; } = maxDamage;
        public int Initiative { get; } = initiative;
    }
}