using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.ModifiersTests;

public class AttackSkillTests
{
    [Fact]

    public void AttackSkill_WhenAttacking_CallsInnerCreatureAttackTwice()
    {
        ICreature mockAttacker = Substitute.For<ICreature>();
        mockAttacker.Attack.Returns(5);
        mockAttacker.Health.Returns(10);

        ICreature mockTarget = Substitute.For<ICreature>();
        mockTarget.Health.Returns(15);

        var attackedSkill = new AttackSkill(mockAttacker);

        attackedSkill.AttackTheCreature(mockTarget);

        mockAttacker.Received(2).AttackTheCreature(mockTarget);
    }

    [Fact]

    public void AttackSkill_InvokesTwiceAttacks()
    {
        ICreature mockAttaker = Substitute.For<ICreature>();
        mockAttaker.Attack.Returns(1000);
        mockAttaker.Health.Returns(666);

        ICreature mockTarget = Substitute.For<ICreature>();
        mockTarget.Health.Returns(5252);

        var attackedSkill1 = new AttackSkill(mockAttaker);

        var attackedSkill2 = new AttackSkill(attackedSkill1);

        attackedSkill2.AttackTheCreature(mockTarget);

        mockAttaker.Received(4).AttackTheCreature(mockTarget);
    }
}