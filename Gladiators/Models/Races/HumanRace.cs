namespace Gladiators.Models.Race
{
    internal class HumanRace : IRace
    {
        public string Name => "Человек";
        public int Damage => 1;
        public int Health => 20;
        public int Armor => 1;
        public int Initiative => 4;
    }
}