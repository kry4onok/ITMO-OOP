using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.PlayersTables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Fight;

public class Battle
{
    private int _selectionIndex = 0;

    public BattleResult Fight(Table table1, Table table2)
    {
        var battleTable1 = new Table();

        var battleTable2 = new Table();

        foreach (ICreature creature in table1.GetAllCreatures())
        {
            battleTable1.AddCreature(creature);
        }

        foreach (ICreature creature in table2.GetAliveCreatures())
        {
            battleTable2.AddCreature(creature);
        }

        int currentPlayer = 1;

        while (true)
        {
            IReadOnlyCollection<ICreature> attackers1 = battleTable1.GetAttackerCreatures();

            IReadOnlyCollection<ICreature> defenders1 = battleTable1.GetDefenderCreatures();

            IReadOnlyCollection<ICreature> attackers2 = battleTable2.GetAttackerCreatures();

            IReadOnlyCollection<ICreature> defenders2 = battleTable2.GetDefenderCreatures();

            bool p1_can_attack = attackers1.Count > 0;
            bool p2_can_attack = attackers2.Count > 0;
            bool p1_can_defend = defenders1.Count > 0;
            bool p2_can_defend = defenders2.Count > 0;

            if (currentPlayer == 1)
            {
                if (!p1_can_attack)
                {
                    if (!p2_can_attack)
                    {
                        return new BattleResult.PlayerDraw();
                    }

                    currentPlayer = 2;
                    continue;
                }

                if (!p2_can_defend)
                {
                    return new BattleResult.Player1Win();
                }

                ICreature attacker = SelectCreature(attackers1);
                ICreature defender = SelectCreature(defenders2);

                attacker.AttackTheCreature(defender);

                battleTable2.RemoveDeadCreatures();

                currentPlayer = 2;
            }
            else
            {
                if (!p2_can_attack)
                {
                    if (!p1_can_attack)
                    {
                        return new BattleResult.PlayerDraw();
                    }

                    currentPlayer = 1;
                    continue;
                }

                if (!p1_can_defend)
                {
                    return new BattleResult.Player2Win();
                }

                ICreature attacker = SelectCreature(attackers2);
                ICreature defender = SelectCreature(defenders1);

                attacker.AttackTheCreature(defender);

                battleTable1.RemoveDeadCreatures();

                currentPlayer = 1;
            }
        }
    }

    private ICreature SelectCreature(IReadOnlyCollection<ICreature> creatures)
    {
        if (creatures.Count == 0)
        {
            throw new InvalidOperationException("Cannot select from empty collection.");
        }

        ICreature selected = creatures.ElementAt(_selectionIndex % creatures.Count);
        _selectionIndex++;
        return selected;
    }
}