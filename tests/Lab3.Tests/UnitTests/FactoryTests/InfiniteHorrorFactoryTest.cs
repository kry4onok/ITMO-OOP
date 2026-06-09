using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.FactoryTests;

public class InfiniteHorrorFactoryTest
{
    [Fact]

    public void Create_InfiniteHorror_Assert_Characteristic()
    {
        var factory = new InfiniteHorrorFactory();

        ICreature creature = factory.CreateCreature();

        Assert.Equal(4, creature.Attack);
        Assert.Equal(4, creature.Health);
    }
}