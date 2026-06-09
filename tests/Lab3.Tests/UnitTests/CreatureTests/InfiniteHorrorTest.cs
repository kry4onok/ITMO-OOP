using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.CreatureTests;

public class InfiniteHorrorTest
{
    [Fact]

    public void InfiniteHorror_SpecificAbility()
    {
        var factory = new InfiniteHorrorFactory();

        ICreature creature = factory.CreateCreature();

        creature.TakeDamage(5);

        Assert.Equal(4, creature.Attack);
        Assert.Equal(1, creature.Health);
    }
}