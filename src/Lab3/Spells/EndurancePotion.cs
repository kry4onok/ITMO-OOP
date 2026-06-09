using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    public ICreature AddBuff(ICreature creature)
    {
        creature.ChangeTheCharacteristics(0, 5);
        return creature;
    }
}