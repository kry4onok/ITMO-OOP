using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.FactoryTests;

public class MasterAmuletFactoryTest
{
    [Fact]

    public void Create_MasterAmulet_Assert_Characteristic()
    {
        var factory = new MasterAmuletFactory();

        ICreature creature = factory.CreateCreature();

        Assert.Equal(5, creature.Attack);
        Assert.Equal(2, creature.Health);
    }
}