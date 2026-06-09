using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

public class MasterAmulet : Creature
{
    private MasterAmulet() : base(5, 2) { }

    public static ICreature Create()
    {
        return new MasterAmulet();
    }

    public override void AttackTheCreature(ICreature target)
    {
        target.TakeDamage(Attack);
    }
}