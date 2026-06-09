using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.CreatureTests;

public class MasterAmuletTest
{
    [Fact]

    public void MasterAmulet_SpecificAbility()
    {
        var factory = new MasterAmuletFactory();

        ICreature creature = factory.CreateCreature();

        ICreature mockCreature = Substitute.For<ICreature>();
        mockCreature.Health.Returns(11);

        creature.AttackTheCreature(mockCreature);

        creature.TakeDamage(1000);

        mockCreature.Received(2).TakeDamage(creature.Attack);
        Assert.Equal(2, creature.Health);
    }
}