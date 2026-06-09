using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

public class ApplyAttackSkill : IApplyModifier
{
    public ICreature Apply(ICreature creature)
    {
        return new AttackSkill(creature);
    }
}