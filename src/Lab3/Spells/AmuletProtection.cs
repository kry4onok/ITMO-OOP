using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class AmuletProtection : ISpell
{
    public ICreature AddBuff(ICreature creature)
    {
        var applyMagicShield = new ApplyMagicShield();
        return applyMagicShield.Apply(creature);
    }
}