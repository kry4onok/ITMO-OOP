using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.CreatureTests;

public class MimicChestTest
{
    [Fact]

    public void MimicChest_SpecificAbility()
    {
        var factory = new MimicChestFactory();

        ICreature creature = factory.CreateCreature();

        ICreature mockCreature = Substitute.For<ICreature>();
        mockCreature.Attack.Returns(100);
        mockCreature.Health.Returns(100);

        creature.AttackTheCreature(mockCreature);

        Assert.Equal(100, creature.Attack);
        Assert.Equal(100, creature.Health);
    }
}