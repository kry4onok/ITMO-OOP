namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record OperationHistoryDTO(
    DateTime OperationTime,
    string Type,
    decimal Amount,
    string Currency,
    bool IsSuccessful,
    string? ErrorMessage);