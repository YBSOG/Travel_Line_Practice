using Gladiators.Models.Armor;
using Gladiators.Models.Class;
using Gladiators.Models.Race;
using Gladiators.Models.Weapon;

namespace Gladiators.Models.Fighter
{
    //Тут данные для создания бойца, расчета его урона,брони и т.д.
    public class FighterCharacteristics( IRace race, IClass @class, IArmor armor, IWeapon weapon )
    {
        public IRace Race { get; } = race;
        public IClass Class { get; } = @class;
        public IArmor Armor { get; } = armor;
        public IWeapon Weapon { get; } = weapon;
    }
}