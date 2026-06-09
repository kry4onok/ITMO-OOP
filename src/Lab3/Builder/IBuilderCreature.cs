using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builder;

public interface IBuilderCreature
{
    IBuilderCreatureModifiers Create(ICreature creature);
}

public interface IBuilderCreatureModifiers
{
    IBuilderCreatureModifiers AddModifier(IApplyModifier modifier);

    IBuilderCreatureModifiers WithModifiers();

    ICreature Build();
}
