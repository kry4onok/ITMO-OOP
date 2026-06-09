using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public abstract class AbstarctModifier : ICreature
{
    protected ICreature Creature { get; }

    protected AbstarctModifier(ICreature creature)
    {
        Creature = creature;
    }

    public int Attack => Creature.Attack;

    public int Health => Creature.Health;

    public virtual void AttackTheCreature(ICreature target)
    {
        Creature.AttackTheCreature(target);
    }

    public virtual void TakeDamage(int damage)
    {
        Creature.TakeDamage(damage);
    }

    public void ChangeTheCharacteristics(int attack, int health)
    {
        Creature.ChangeTheCharacteristics(attack, health);
    }

    public string GetCharacteristics()
    {
        return Creature.GetCharacteristics();
    }

    public virtual ICreature Clone()
    {
        return Creature.Clone();
    }
}