namespace Gladiators.Models.Race
{
    public interface IRace : IModel
    {
        int Damage { get; }
        int Health { get; }
        int Armor { get; }
        public int Initiative { get; }
    }
}
