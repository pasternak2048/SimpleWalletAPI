using AutoMapper;
using Domain.Entities;

namespace Application.Features.TransactionFeatures.GetTransaction
{
    public class GetTransactionMapper : Profile
    {
        public GetTransactionMapper()
        {
            CreateMap<Transaction, GetTransactionResponse>();
        }
    }
}
