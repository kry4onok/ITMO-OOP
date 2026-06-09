using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

public class CombatAnalyst : Creature
{
    private CombatAnalyst() : base(2, 4) { }

    public static ICreature Create()
    {
        return new CombatAnalyst();
    }

    public override void AttackTheCreature(ICreature target)
    {
        ChangeTheCharacteristics(2, 0);

        target.TakeDamage(Attack);
    }
}