namespace Gladiators.Models.Fighter
{
    public interface IFighter : IModel
    {
        public FighterCharacteristics FighterCharacteristics { get; }
        public FighterStatus FighterStatus { get; }
        public int TakeDamage( int damage, int currentHp );
        public int CalculateAttackDamage();
    }
}