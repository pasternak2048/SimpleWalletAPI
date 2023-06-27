using Domain.Enums;
using MediatR;

namespace Application.Features.TransactionFeatures.CreateTransaction
{
    public sealed record CreateTransactionRequest(Guid CardId,
        string Name,
        string Description,
        TransactionTypeEnum TransactionTypeId,
        double Sum) : IRequest<CreateTransactionResponse>;
}
