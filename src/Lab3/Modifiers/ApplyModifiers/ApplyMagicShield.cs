using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

public class ApplyMagicShield : IApplyModifier
{
    public ICreature Apply(ICreature creature)
    {
        return new MagicShield(creature);
    }
}