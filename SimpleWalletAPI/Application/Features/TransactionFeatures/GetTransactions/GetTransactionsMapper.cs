using AutoMapper;
using Domain.Entities;

namespace Application.Features.TransactionFeatures.GetTransactions
{
    public class GetTransactionsMapper : Profile
    {
        public GetTransactionsMapper() 
        {
            CreateMap<GetTransactionsRequest, Transaction>();
            CreateMap<Transaction, GetTransactionsResponse>();
        }
    }
}
