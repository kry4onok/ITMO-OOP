using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.ModifiersTests;

public class ComboModifiersTests
{
    [Fact]

    public void AttackSkill_WithMagicShield_Double_AttackTheCreature()
    {
        ICreature mockAttacker = Substitute.For<ICreature>();
        mockAttacker.Attack.Returns(5);
        mockAttacker.Health.Returns(10);

        ICreature mockTarget = Substitute.For<ICreature>();
        mockTarget.Health.Returns(15);

        var attackedSkill = new AttackSkill(mockAttacker);

        var shielded = new MagicShield(attackedSkill);

        shielded.AttackTheCreature(mockTarget);

        mockAttacker.Received(2).AttackTheCreature(mockTarget);
    }

    [Fact]

    public void MagicShield_WithttackSkill_Double_AttackTheCreature()
    {
        ICreature mockAttacker = Substitute.For<ICreature>();
        mockAttacker.Attack.Returns(5);
        mockAttacker.Health.Returns(10);

        ICreature mockTarget = Substitute.For<ICreature>();
        mockTarget.Health.Returns(15);

        var shielded = new MagicShield(mockAttacker);

        var attackedSkill = new AttackSkill(shielded);

        attackedSkill.AttackTheCreature(mockTarget);

        mockAttacker.Received(2).AttackTheCreature(mockTarget);
    }

    [Fact]

    public void MagicShield_WithAttackSkill_BlockDamage()
    {
        ICreature mockDefender = Substitute.For<ICreature>();

        var shielded = new MagicShield(mockDefender);

        var attackedSkill = new AttackSkill(shielded);

        attackedSkill.TakeDamage(20);

        mockDefender.DidNotReceive().TakeDamage(Arg.Any<int>());
    }

    [Fact]

    public void AttackSkill_WithMagicShield_BlockDamage()
    {
        ICreature mockDefender = Substitute.For<ICreature>();

        var attackedSkill = new AttackSkill(mockDefender);

        var shielded = new MagicShield(attackedSkill);

        shielded.TakeDamage(20);

        mockDefender.DidNotReceive().TakeDamage(Arg.Any<int>());
    }
}