namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record WithdrawDTO(
    decimal NewBalance, string Currency);