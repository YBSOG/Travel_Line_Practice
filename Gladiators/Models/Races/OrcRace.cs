namespace Gladiators.Models.Race
{
    internal class OrcRace : IRace
    {
        public string Name => "Орк";
        public int Damage => 3;
        public int Health => 30;
        public int Armor => 2;
        public int Initiative => 1;
    }
}
