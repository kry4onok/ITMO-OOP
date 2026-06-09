namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Models;

public record CreateAccountModel(
    string AccountNumber,
    string PinCode,
    decimal InitialBalance,
    string Currency);
