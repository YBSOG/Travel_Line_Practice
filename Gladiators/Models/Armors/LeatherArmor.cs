namespace Gladiators.Models.Armor
{
    public class LeatherArmor : IArmor
    {
        public string Name => "Кожанная броня";
        public int Armor => 2;
        public int Initiative => 2;
    }
}