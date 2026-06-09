using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature AddBuff(ICreature creature)
    {
        creature.ChangeTheCharacteristics(
            creature.Health - creature.Attack,
            creature.Attack - creature.Health);

        return creature;
    }
}