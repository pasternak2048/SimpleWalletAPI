using AutoMapper;
using Domain.Entities;

namespace Application.Features.TransactionFeatures.GetViewTransaction
{
    public class GetViewTransactionMapper : Profile
    {
        public GetViewTransactionMapper() {
            CreateMap<GetViewTransactionRequest, ViewTransaction>();
            CreateMap<ViewTransaction, GetViewTransactionResponse>();
        }
    }
}
