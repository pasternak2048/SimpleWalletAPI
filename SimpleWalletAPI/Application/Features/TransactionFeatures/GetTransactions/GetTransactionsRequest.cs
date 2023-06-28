using MediatR;

namespace Application.Features.TransactionFeatures.GetTransactions
{
    public sealed record GetTransactionsRequest(Guid? CardId, int PageNumber = 1, int PageSize = 10): IRequest<List<GetTransactionsResponse>>;
}
