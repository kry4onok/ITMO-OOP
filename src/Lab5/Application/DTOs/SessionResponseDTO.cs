using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;

public sealed record SessionResponseDTO(
    SessionId Id,
    string AccountNumber);