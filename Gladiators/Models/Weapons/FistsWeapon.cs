namespace Gladiators.Models.Weapon
{
    public class FistsWeapon : IWeapon
    {
        public string Name => "Кулаки";
        public int Damage => 2;
        public int Initiative => 6;
    }
}