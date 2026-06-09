using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Ports;

public interface ISession
{
    SessionId Id { get; }

    DateTime CreatedIn { get; }
}