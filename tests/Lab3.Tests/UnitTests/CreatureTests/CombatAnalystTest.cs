using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.CreatureTests;

public class CombatAnalystTest
{
    [Fact]

    public void CombatAnalyst_SpecificAbility()
    {
        var factory = new CombatAnalystFactory();

        ICreature creature = factory.CreateCreature();
        ICreature mockCreature = Substitute.For<ICreature>();

        creature.AttackTheCreature(mockCreature);

        Assert.Equal(4, creature.Attack);
        Assert.Equal(4, creature.Health);
    }
}