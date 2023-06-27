using MediatR;

namespace Application.Features.TransactionFeatures.GetTransactions
{
    public sealed record GetTransactionsRequest(Guid? CardId, int PageNumber, int PageSize): IRequest<List<GetTransactionsResponse>>;
}
