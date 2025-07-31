namespace Gladiators.Models.Weapon
{
    public interface IWeapon : IModel
    {
        int Damage { get; }
        int Initiative { get; }
    }
}