using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.ModifiersTests;

public class MagicShieldTests
{
    [Fact]

    public void MagicShieldApplyWithMock()
    {
        ICreature mockDefender = Substitute.For<ICreature>();

        var shielded = new MagicShield(mockDefender);

        shielded.TakeDamage(20);

        mockDefender.DidNotReceive().TakeDamage(Arg.Any<int>());
    }

    [Fact]

    public void ComboMagicShieldApplyWithMock()
    {
        ICreature mockDefender = Substitute.For<ICreature>();

        var shielded1 = new MagicShield(mockDefender);

        var shielded2 = new MagicShield(shielded1);

        shielded2.TakeDamage(10000);

        shielded2.TakeDamage(10000);

        shielded2.TakeDamage(1);

        mockDefender.Received(1).TakeDamage(1);
    }
}