using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builder;

public class BuilderCreature : IBuilderCreature, IBuilderCreatureModifiers
{
    private readonly List<IApplyModifier> _modifiers = new List<IApplyModifier>();

    private ICreature? _baseCreature;

    private BuilderCreature() { }

    public static IBuilderCreature Start()
    {
        return new BuilderCreature();
    }

    public IBuilderCreatureModifiers Create(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        _baseCreature = creature;

        return this;
    }

    public IBuilderCreatureModifiers AddModifier(IApplyModifier modifier)
    {
        ArgumentNullException.ThrowIfNull(modifier);

        _modifiers.Add(modifier);

        return this;
    }

    public IBuilderCreatureModifiers WithModifiers()
    {
        return this;
    }

    public ICreature Build()
    {
        if (_baseCreature == null)
        {
            throw new InvalidOperationException("Base creature must be set!");
        }

        ICreature result = _baseCreature;

        foreach (IApplyModifier modifier in _modifiers)
        {
            result = modifier.Apply(result);
        }

        return result;
    }
}