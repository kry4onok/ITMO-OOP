using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.SpellTests;

public class EndurancePotionTests
{
    [Fact]

    public void EndurancePotion_ApplyCreature()
    {
        var factory = new CombatAnalystFactory();

        ICreature creature = factory.CreateCreature();

        var spell = new EndurancePotion();

        spell.AddBuff(creature);

        Assert.Equal(9, creature.Health);
    }

    [Fact]

    public void EndurancePotion_ApplyTwoCreature()
    {
        var factory1 = new InfiniteHorrorFactory();

        var factory2 = new CombatAnalystFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var spell = new EndurancePotion();

        spell.AddBuff(creature1);
        spell.AddBuff(creature2);

        Assert.Equal(9, creature1.Health);
        Assert.Equal(9, creature2.Health);
    }
}