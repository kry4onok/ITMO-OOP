using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;

public interface ICreatureFactory
{
    ICreature CreateCreature();
}