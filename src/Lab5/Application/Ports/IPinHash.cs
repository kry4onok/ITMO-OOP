namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface IPinHash
{
    string Hash(string plainPin);

    bool Verify(string plainPin, string hash);
}