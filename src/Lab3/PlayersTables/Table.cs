using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.PlayersTables;

public class Table()
{
    private readonly LimitedList<ICreature> creatures = new LimitedList<ICreature>(7);

    public int CreatureCount => creatures.Count;

    public void AddCreature(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        ICreature cloneCreature = creature.Clone();
        creatures.Add(cloneCreature);
    }

    public void ApplySpell(ISpell spell, ICreature target)
    {
        ArgumentNullException.ThrowIfNull(spell);
        ArgumentNullException.ThrowIfNull(target);

        spell.AddBuff(target);
    }

    public IReadOnlyCollection<ICreature> GetAliveCreatures()
    {
        var alive = new List<ICreature>();

        foreach (ICreature creature in creatures)
        {
            if (creature.Health > 0)
            {
                alive.Add(creature);
            }
        }

        return alive;
    }

    public void RemoveDeadCreatures()
    {
        var dead = new List<ICreature>();

        foreach (ICreature creature in creatures)
        {
            if (creature.Health <= 0)
            {
                dead.Add(creature);
            }
        }

        foreach (ICreature deadCreature in dead)
        {
            creatures.Remove(deadCreature);
        }
    }

    public IReadOnlyCollection<ICreature> GetAttackerCreatures()
    {
        IReadOnlyCollection<ICreature> isAlive = GetAliveCreatures();
        var attackerList = new List<ICreature>();

        foreach (ICreature creature in isAlive)
        {
            if (creature.Attack > 0)
            {
                attackerList.Add(creature);
            }
        }

        return attackerList;
    }

    public IReadOnlyCollection<ICreature> GetDefenderCreatures()
    {
        return GetAliveCreatures();
    }

    public IReadOnlyCollection<ICreature> GetAllCreatures()
    {
        var result = new List<ICreature>();

        foreach (ICreature creature in creatures)
        {
            result.Add(creature.Clone());
        }

        return result;
    }
}