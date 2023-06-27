using MediatR;

namespace Application.Features.TransactionFeatures.GetTransaction
{
    public sealed record GetTransactionRequest(Guid TransactionId) : IRequest<GetTransactionResponse>;
}
