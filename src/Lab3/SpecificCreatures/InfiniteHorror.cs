using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

public class InfiniteHorror : Creature
{
    private bool reborn = true;

    private InfiniteHorror() : base(4, 4) { }

    public static ICreature Create()
    {
        return new InfiniteHorror();
    }

    public override void TakeDamage(int damage)
    {
        bool isAlive = damage >= Health;
        base.TakeDamage(damage);

        if (isAlive && reborn)
        {
            Health = 1;
            reborn = false;
        }
    }

    public override void AttackTheCreature(ICreature target)
    {
        target.TakeDamage(Attack);
    }

    public override ICreature Clone()
    {
        return (InfiniteHorror)MemberwiseClone();
    }
}