namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record AccountDetailDTO(
    string AccountNumber,
    decimal Balance,
    decimal OperationCount);