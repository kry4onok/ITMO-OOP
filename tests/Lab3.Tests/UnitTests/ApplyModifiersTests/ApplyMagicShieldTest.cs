using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.ApplyModifiersTests;

public class ApplyMagicShieldTest
{
    [Fact]

    public void Apply_MagicShield_To_EvilFighter()
    {
        ICreature mockCreature = Substitute.For<ICreature>();

        var applyMagicShield = new ApplyMagicShield();

        ICreature mockCreatureMagicShield = applyMagicShield.Apply(mockCreature);

        mockCreatureMagicShield.TakeDamage(1000);

        mockCreature.DidNotReceive().TakeDamage(Arg.Any<int>());
    }
}