using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.CreatureTests;

public class EvilFighterTest
{
    [Fact]

    public void EvilFighter_SpecificAbility()
    {
        var factory = new EvilFighterFactory();

        ICreature creature = factory.CreateCreature();

        creature.TakeDamage(2);

        Assert.Equal(2, creature.Attack);
        Assert.Equal(4, creature.Health);
    }
}