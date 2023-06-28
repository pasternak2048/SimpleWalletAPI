using MediatR;

namespace Application.Features.TransactionFeatures.GetViewTransaction
{
    public sealed record GetViewTransactionRequest(Guid TransactionId) : IRequest<GetViewTransactionResponse>;
}
