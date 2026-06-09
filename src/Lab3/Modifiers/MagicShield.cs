using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : AbstarctModifier
{
    private bool isAlive = true;

    public MagicShield(ICreature creature) : base(creature) { }

    public override void TakeDamage(int damage)
    {
        if (isAlive)
        {
            isAlive = false;
            return;
        }

        Creature.TakeDamage(damage);
    }

    public override ICreature Clone()
    {
        return new MagicShield(Creature.Clone());
    }
}