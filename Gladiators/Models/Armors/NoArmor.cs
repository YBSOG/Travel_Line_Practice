namespace Gladiators.Models.Armor
{
    public class NoArmor : IArmor
    {
        public string Name => "Без брони";
        public int Armor => 0;
        public int Initiative => 4;
    }
}