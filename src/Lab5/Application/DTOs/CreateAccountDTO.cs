namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record CreateAccountDTO(
    string AccountNumber,
    string PinCode,
    decimal InitialBalance,
    string Currency);
