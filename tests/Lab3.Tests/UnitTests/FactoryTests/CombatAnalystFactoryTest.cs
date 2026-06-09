using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.FactoryTests;

public class CombatAnalystFactoryTest
{
    [Fact]

    public void Create_CombatAnalyst_Assert_Characteristic()
    {
        var factory = new CombatAnalystFactory();

        ICreature creature = factory.CreateCreature();

        Assert.Equal(2, creature.Attack);
        Assert.Equal(4, creature.Health);
    }
}