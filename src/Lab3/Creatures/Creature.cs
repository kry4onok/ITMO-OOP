namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class Creature : ICreature
{
    public int Attack { get; protected set; }

    public int Health { get; protected set; }

    protected Creature(int attack, int health)
    {
        Attack = attack;
        Health = health;
    }

    public abstract void AttackTheCreature(ICreature target);

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void ChangeTheCharacteristics(int attack, int health)
    {
        Attack += attack;
        Health += health;
    }

    public string GetCharacteristics()
    {
        return $"{Attack}/{Health}";
    }

    public virtual ICreature Clone()
    {
        return (ICreature)MemberwiseClone();
    }
}