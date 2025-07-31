namespace Gladiators.Models.Weapon
{
    public class AxeWeapon : IWeapon
    {
        public string Name => "Топор";
        public int Damage => 7;
        public int Initiative => 1;
    }
}