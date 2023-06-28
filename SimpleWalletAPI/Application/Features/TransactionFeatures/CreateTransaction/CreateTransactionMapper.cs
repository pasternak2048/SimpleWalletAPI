using Application.Extensions;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.TransactionFeatures.CreateTransaction
{
    public class CreateTransactionMapper : Profile
    {
        public CreateTransactionMapper()
        {
            CreateMap<CreateTransactionRequest, Transaction>();
            CreateMap<Transaction, CreateTransactionResponse>();
        }
    }
}
