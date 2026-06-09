using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.FactoryTests;

public class MimicChestFactoryTest
{
    [Fact]

    public void Create_MimicChest_Assert_Characteristic()
    {
        var factory = new MimicChestFactory();

        ICreature creature = factory.CreateCreature();

        Assert.Equal(1, creature.Attack);
        Assert.Equal(1, creature.Health);
    }
}