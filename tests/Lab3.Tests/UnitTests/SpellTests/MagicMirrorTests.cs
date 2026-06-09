using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.SpellTests;

public class MagicMirrorTests
{
    [Fact]

    public void MagicMirror_ApplyCreature()
    {
        var factory = new MasterAmuletFactory();

        ICreature creature = factory.CreateCreature();

        var spell = new MagicMirror();

        spell.AddBuff(creature);

        Assert.Equal(2, creature.Attack);
        Assert.Equal(5, creature.Health);
    }

    [Fact]

    public void MagicMirror_ApplyTwoCreature()
    {
        var factory1 = new EvilFighterFactory();

        var factory2 = new CombatAnalystFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var spell = new MagicMirror();

        spell.AddBuff(creature1);
        spell.AddBuff(creature2);

        Assert.Equal(6, creature1.Attack);
        Assert.Equal(1, creature1.Health);

        Assert.Equal(4, creature2.Attack);
        Assert.Equal(2, creature2.Health);
    }
}