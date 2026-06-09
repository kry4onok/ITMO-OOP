using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    public ICreature AddBuff(ICreature creature)
    {
        creature.ChangeTheCharacteristics(5, 0);
        return creature;
    }
}