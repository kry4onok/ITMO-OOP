using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.SpecificCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;

public class EvilFighterFactory : ICreatureFactory
{
    public ICreature CreateCreature()
    {
        return EvilFighter.Create();
    }
}