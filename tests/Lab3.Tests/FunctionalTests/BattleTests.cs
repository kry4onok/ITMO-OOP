using Itmo.ObjectOrientedProgramming.Lab3.Builder;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Fight;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;
using Itmo.ObjectOrientedProgramming.Lab3.PlayersTables;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.FunctionalTests;

public class BattleTests
{
    [Fact]
    public void Battle_BothPlayersWithCreatures_ShouldHaveWinner()
    {
        var factory1 = new EvilFighterFactory();
        var factory2 = new CombatAnalystFactory();

        var battle = new Battle();
        var table1 = new Table();
        var table2 = new Table();

        table1.AddCreature(factory2.CreateCreature());
        table2.AddCreature(factory1.CreateCreature());

        BattleResult result = battle.Fight(table1, table2);

        Assert.IsType<BattleResult.Player1Win>(result);
    }

    [Fact]

    public void Battle_With_Empty_Tables()
    {
        var table1 = new Table();
        var table2 = new Table();
        var battle = new Battle();

        BattleResult result = battle.Fight(table1, table2);

        Assert.IsType<BattleResult.PlayerDraw>(result);
    }

    [Fact]

    public void Battle_BothPlayer_With_FullTable_Creature()
    {
        var factory1 = new EvilFighterFactory();
        var factory2 = new CombatAnalystFactory();
        var factory3 = new MimicChestFactory();
        var factory4 = new MasterAmuletFactory();
        var factory5 = new InfiniteHorrorFactory();

        ICreature player1Creature1 = factory1.CreateCreature();

        ICreature player1Creature2 = factory2.CreateCreature();

        ICreature player1Creature3 = factory3.CreateCreature();

        ICreature player1Creature4 = factory4.CreateCreature();

        ICreature player1Creature5 = factory5.CreateCreature();

        ICreature player1Creature6 = BuilderCreature.Start()
        .Create(factory2.CreateCreature())
        .AddModifier(new ApplyAttackSkill())
        .WithModifiers()
        .Build();

        ICreature player1Creature7 = BuilderCreature.Start()
        .Create(factory3.CreateCreature())
        .AddModifier(new ApplyMagicShield())
        .WithModifiers()
        .Build();

        var spell1 = new EndurancePotion();
        var spell2 = new PowerPotion();
        var spell3 = new AmuletProtection();
        var spell4 = new MagicMirror();

        ICreature player2Creature1 = BuilderCreature.Start()
        .Create(factory4.CreateCreature())
        .AddModifier(new ApplyAttackSkill())
        .AddModifier(new ApplyMagicShield())
        .WithModifiers()
        .Build();

        ICreature player2Creature2 = BuilderCreature.Start()
        .Create(factory2.CreateCreature())
        .AddModifier(new ApplyMagicShield())
        .WithModifiers()
        .Build();

        ICreature player2Creature3 = BuilderCreature.Start()
        .Create(factory4.CreateCreature())
        .AddModifier(new ApplyMagicShield())
        .WithModifiers()
        .Build();

        ICreature player2Creature4 = BuilderCreature.Start()
        .Create(factory3.CreateCreature())
        .WithModifiers()
        .Build();

        ICreature player2Creature5 = BuilderDirector.AllBuffEvilFighter();

        ICreature player2Creature6 = BuilderDirector.AllBuffInfiniteHorror();

        ICreature player2Creature7 = BuilderDirector.AllBuffMimicChest();

        var battle = new Battle();
        var table1 = new Table();
        var table2 = new Table();

        table1.AddCreature(player1Creature1);
        table1.AddCreature(player1Creature2);
        table1.AddCreature(player1Creature3);
        table1.AddCreature(player1Creature4);
        table1.AddCreature(player1Creature5);
        table1.AddCreature(player1Creature6);
        table1.AddCreature(player1Creature7);

        table1.ApplySpell(spell1, player1Creature1);
        table1.ApplySpell(spell2, player1Creature2);
        table1.ApplySpell(spell3, player1Creature3);
        table1.ApplySpell(spell4, player1Creature4);

        table2.AddCreature(player2Creature1);
        table2.AddCreature(player2Creature2);
        table2.AddCreature(player2Creature3);
        table2.AddCreature(player2Creature4);
        table2.AddCreature(player2Creature5);
        table2.AddCreature(player2Creature6);
        table2.AddCreature(player2Creature7);

        table2.ApplySpell(spell1, player2Creature1);
        table2.ApplySpell(spell2, player2Creature2);
        table2.ApplySpell(spell3, player2Creature3);
        table2.ApplySpell(spell4, player2Creature4);

        BattleResult result = battle.Fight(table1, table2);

        Assert.IsType<BattleResult.Player2Win>(result);
    }
}