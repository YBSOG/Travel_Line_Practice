namespace Gladiators.Models.Weapon
{
    public class SwordWeapon : IWeapon
    {
        public string Name => "Меч";
        public int Damage => 4;
        public int Initiative => 3;
    }
}