using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.FactoryTests;

public class EvilFighterFactoryTest
{
    [Fact]

    public void Create_EvilFighter_Assert_Characteristic()
    {
        var factory = new EvilFighterFactory();

        ICreature creature = factory.CreateCreature();

        Assert.Equal(1, creature.Attack);
        Assert.Equal(6, creature.Health);
    }
}