using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;

public class MimicChestFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return MimicChest.Create();
    }
}