namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature : IClone
{
    int Attack { get; }

    int Health { get; }

    void AttackTheCreature(ICreature target);

    void TakeDamage(int damage);

    void ChangeTheCharacteristics(int attack, int health);

    string GetCharacteristics();
}

public interface IClone
{
    ICreature Clone();
}