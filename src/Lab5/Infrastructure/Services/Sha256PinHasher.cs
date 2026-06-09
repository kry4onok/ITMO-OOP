using Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;
using System.Security.Cryptography;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Services;

public sealed class Sha256PinHasher : IPinHash
{
    public string Hash(string plainPin)
    {
        byte[] pinBytes = Encoding.UTF8.GetBytes(plainPin);

        byte[] hashBytes = SHA256.HashData(pinBytes);

        return Convert.ToBase64String(hashBytes);
    }

    public bool Verify(string plainPin, string hash)
    {
        string hashPin = Hash(plainPin);

        return hash == hashPin;
    }
}