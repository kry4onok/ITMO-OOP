using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

public interface IApplyModifier
{
    ICreature Apply(ICreature creature);
}