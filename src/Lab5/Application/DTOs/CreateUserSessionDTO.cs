namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record CreateUserSessionDTO(
    string AccountNumber,
    string PinCode);