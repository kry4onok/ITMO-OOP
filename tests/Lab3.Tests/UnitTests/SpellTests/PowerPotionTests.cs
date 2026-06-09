using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.SpellTests;

public class PowerPotionTests
{
    [Fact]

    public void PowerPotion_ApplyCreature()
    {
        var factory = new CombatAnalystFactory();

        ICreature creature = factory.CreateCreature();

        var spell = new PowerPotion();

        spell.AddBuff(creature);

        Assert.Equal(7, creature.Attack);
    }

    [Fact]

    public void OneHundred_PowerPotion_ApplyCreature()
    {
        var factory = new InfiniteHorrorFactory();

        ICreature creature = factory.CreateCreature();

        var spell = new PowerPotion();

        for (int i = 0; i < 100; ++i)
        {
            spell.AddBuff(creature);
        }

        Assert.Equal(504, creature.Attack);
    }

    [Fact]

    public void PowerPotion_ApplyTwoCreature()
    {
        var factory1 = new InfiniteHorrorFactory();

        var factory2 = new CombatAnalystFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var spell = new PowerPotion();

        spell.AddBuff(creature1);
        spell.AddBuff(creature2);

        Assert.Equal(9, creature1.Attack);
        Assert.Equal(7, creature2.Attack);
    }
}