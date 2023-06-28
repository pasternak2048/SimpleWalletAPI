
using AutoMapper;
using Domain.Entities;

namespace Application.Features.TransactionFeatures.GetViewTransactions
{
    public class GetViewTransactionsMapper : Profile
    {
        public GetViewTransactionsMapper()
        {
            CreateMap<GetViewTransactionsRequest, ViewTransaction>();
            CreateMap<ViewTransaction, GetViewTransactionsResponse>();
        }
    }
}
