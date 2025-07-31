namespace Gladiators.Models.Armor
{
    public interface IArmor : IModel
    {
        int Armor { get; }
        int Initiative { get; }
    }
}