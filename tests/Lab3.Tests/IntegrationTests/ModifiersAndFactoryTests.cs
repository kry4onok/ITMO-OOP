using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.IntegrationTests;

public class ModifiersAndFactoryTests
{
    [Fact]

    public void AttackSkill_ApplyMimicChest_And_Attack_MasterAmulet()
    {
        var factory1 = new MimicChestFactory();

        var factory2 = new MasterAmuletFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var attackedSkill = new AttackSkill(creature1);

        attackedSkill.AttackTheCreature(creature2);

        Assert.Equal(2, creature1.Health);
        Assert.Equal(5, creature1.Attack);

        Assert.Equal(-3, creature2.Health);
        Assert.Equal(5, creature2.Attack);
    }

    [Fact]

    public void MagicShield_Apply_EvilFighter_Versus_MasterAmulet()
    {
        var factory1 = new EvilFighterFactory();

        var factory2 = new MasterAmuletFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var shielded = new MagicShield(creature1);

        creature2.AttackTheCreature(shielded);

        Assert.Equal(1, creature1.Health);
        Assert.Equal(2, creature1.Attack);

        Assert.Equal(2, creature2.Health);
        Assert.Equal(5, creature2.Attack);
    }

    [Fact]

    public void MagicShield_Apply_InfiniteHorror_Versus_MasterAmulet()
    {
        var factory1 = new InfiniteHorrorFactory();

        var factory2 = new MasterAmuletFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var shielded = new MagicShield(creature1);

        creature2.AttackTheCreature(shielded);

        Assert.Equal(1, creature1.Health);
        Assert.Equal(4, creature1.Attack);

        Assert.Equal(2, creature2.Health);
        Assert.Equal(5, creature2.Attack);
    }

    [Fact]

    public void MagicShield_Apply_CombatAnalyst_Versus_MasterAmulet()
    {
        var factory1 = new CombatAnalystFactory();

        var factory2 = new MasterAmuletFactory();

        ICreature creature1 = factory1.CreateCreature();

        ICreature creature2 = factory2.CreateCreature();

        var shielded = new MagicShield(creature1);

        creature2.AttackTheCreature(shielded);

        Assert.Equal(-1, creature1.Health);
        Assert.Equal(2, creature1.Attack);

        Assert.Equal(2, creature2.Health);
        Assert.Equal(5, creature2.Attack);
    }
}