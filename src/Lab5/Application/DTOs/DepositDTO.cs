namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record DepositDTO(
    decimal NewBalance, string Currency);