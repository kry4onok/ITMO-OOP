using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.SpellTests;

public class AmuletProtectionTests
{
    [Fact]

    public void AmuletProtection_ApplyCreature()
    {
        ICreature mockCreature = Substitute.For<ICreature>();

        var spell = new AmuletProtection();

        ICreature creatureWithAmulet = spell.AddBuff(mockCreature);

        creatureWithAmulet.TakeDamage(1000);

        mockCreature.DidNotReceive().TakeDamage(Arg.Any<int>());
    }
}