using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Session;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class SessionMapper
{
    public static SessionResponseDTO ToResponseDTO(this AdminSession session)
    {
        return new SessionResponseDTO(
            Id: session.Id,
            AccountNumber: "ADMIN");
    }

    public static SessionResponseDTO ToResponseDTO(this UserSession session)
    {
        return new SessionResponseDTO(
            Id: session.Id,
            AccountNumber: session.AccountNumber.Value);
    }
}