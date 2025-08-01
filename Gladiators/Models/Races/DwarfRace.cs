namespace Gladiators.Models.Race
{
    internal class DwarfRace : IRace
    {
        public string Name => "Дворф";
        public int Damage => 2;
        public int Health => 25;
        public int Armor => 3;
        public int Initiative => 2;
    }
}
