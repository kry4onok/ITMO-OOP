using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;

public class MasterAmuletFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        ICreature creature = MasterAmulet.Create();
        creature = new AttackSkill(creature);
        creature = new MagicShield(creature);
        return creature;
    }
}