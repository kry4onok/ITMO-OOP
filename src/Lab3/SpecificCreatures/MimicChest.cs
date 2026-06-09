using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

public class MimicChest : Creature
{
    private MimicChest() : base(1, 1) { }

    public static ICreature Create()
    {
        return new MimicChest();
    }

    public override void AttackTheCreature(ICreature target)
    {
        int maxAttack = Math.Max(Attack, target.Attack);
        int maxHealth = Math.Max(Health, target.Health);

        ChangeTheCharacteristics(maxAttack - Attack, maxHealth - Health);

        target.TakeDamage(Attack);
    }
}