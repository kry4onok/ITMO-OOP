using Itmo.ObjectOrientedProgramming.Lab5.Application.DTOs;
using Itmo.ObjectOrientedProgramming.Lab5.DomainModel.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class HistoryMapper
{
    public static IEnumerable<OperationHistoryDTO> ToHistoryDTOs(
        this IEnumerable<HistoryOperationAccount> history)
    {
        return history.Select(op => op.ToHistoryDTO());
    }

    public static OperationHistoryDTO ToHistoryDTO(this HistoryOperationAccount operation)
    {
        return new OperationHistoryDTO(
            OperationTime: operation.OperationTime,
            Type: operation.Type,
            Amount: operation.Amount.Amount,
            Currency: operation.Amount.Currency.Code,
            IsSuccessful: operation.IsSuccessful,
            ErrorMessage: operation.ErrorMessage);
    }
}