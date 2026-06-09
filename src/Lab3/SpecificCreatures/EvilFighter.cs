using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

public class EvilFighter : Creature
{
    private EvilFighter() : base(1, 6) { }

    public static ICreature Create()
    {
        return new EvilFighter();
    }

    public override void TakeDamage(int damage)
    {
        bool isAlive = damage < Health;
        base.TakeDamage(damage);

        if (isAlive)
        {
            Attack *= 2;
        }
    }

    public override void AttackTheCreature(ICreature target)
    {
        target.TakeDamage(Attack);
    }

    public override ICreature Clone()
    {
        return (EvilFighter)MemberwiseClone();
    }
}