using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.FactoryMethod;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ApplyModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builder;

public static class BuilderDirector
{
    public static ICreature AllBuffEvilFighter()
    {
        var fabric = new EvilFighterFactory();

        return BuilderCreature.Start()
                .Create(fabric.CreateCreature())
                .AddModifier(new ApplyAttackSkill())
                .AddModifier(new ApplyMagicShield())
                .WithModifiers()
                .Build();
    }

    public static ICreature AllBuffInfiniteHorror()
    {
        var fabric = new InfiniteHorrorFactory();

        return BuilderCreature.Start()
                .Create(fabric.CreateCreature())
                .AddModifier(new ApplyAttackSkill())
                .AddModifier(new ApplyMagicShield())
                .WithModifiers()
                .Build();
    }

    public static ICreature AllBuffMimicChest()
    {
        var fabric = new MimicChestFactory();

        return BuilderCreature.Start()
                .Create(fabric.CreateCreature())
                .AddModifier(new ApplyAttackSkill())
                .AddModifier(new ApplyMagicShield())
                .WithModifiers()
                .Build();
    }

    public static ICreature AllBuffCombatAnalyst()
    {
        var fabric = new CombatAnalystFactory();

        return BuilderCreature.Start()
                .Create(fabric.CreateCreature())
                .AddModifier(new ApplyMagicShield())
                .AddModifier(new ApplyAttackSkill())
                .WithModifiers()
                .Build();
    }
}