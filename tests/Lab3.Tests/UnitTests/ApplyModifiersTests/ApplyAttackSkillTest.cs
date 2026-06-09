using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.UnitTests.ApplyModifiersTests;

public class ApplyAttackSkillTest
{
    [Fact]

    public void Apply_AttackSkill_Creature()
    {
        ICreature mockCreature = Substitute.For<ICreature>();
        mockCreature.Attack.Returns(1000);
        mockCreature.Health.Returns(10);

        ICreature mockTarget = Substitute.For<ICreature>();
        mockTarget.Health.Returns(100);

        var applyAttackSkill = new ApplyAttackSkill();

        ICreature mockCreatureAttackSkill = applyAttackSkill.Apply(mockCreature);

        mockCreatureAttackSkill.AttackTheCreature(mockTarget);

        mockCreature.Received(2).AttackTheCreature(mockTarget);
    }
}