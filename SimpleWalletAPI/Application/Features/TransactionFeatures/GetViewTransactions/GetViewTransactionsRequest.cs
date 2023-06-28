using MediatR;

namespace Application.Features.TransactionFeatures.GetViewTransactions
{
    public sealed record GetViewTransactionsRequest(Guid? UserId, Guid? CardId, int PageNumber = 1, int PageSize = 10) : IRequest<List<GetViewTransactionsResponse>>;
}
