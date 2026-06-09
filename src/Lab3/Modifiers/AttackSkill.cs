using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackSkill : AbstarctModifier
{
    public AttackSkill(ICreature creature) : base(creature) { }

    public override void AttackTheCreature(ICreature target)
    {
        Creature.AttackTheCreature(target);
        if (Creature.Health > 0 && Creature.Attack > 0 && target.Health > 0)
        {
            Creature.AttackTheCreature(target);
        }
    }

    public override ICreature Clone()
    {
        return new AttackSkill(Creature.Clone());
    }
}