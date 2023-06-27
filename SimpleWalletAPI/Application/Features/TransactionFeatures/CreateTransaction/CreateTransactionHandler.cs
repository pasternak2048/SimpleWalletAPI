using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.TransactionFeatures.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, CreateTransactionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionHandler(IUnitOfWork unitOfWork, ICardRepository cardRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(request.CardId, cancellationToken);
            var balance = card.Balance;

            if (card == null)
            {
                throw new NotFoundException("Card", request.CardId);
            }

            switch (request.TransactionTypeId)
            {
                case TransactionTypeEnum.Payment:
                    {
                        if(card.Balance + request.Sum > 1500.0)
                        {
                            throw new BalanceException($"Balance can`t be bigger than {card.BalanceLimit}");
                        }

                        card.Balance = card.Balance + request.Sum;
                        break;
                    }

                case TransactionTypeEnum.Credit:
                    {
                        if (card.Balance - request.Sum < 0)
                        {
                            throw new BalanceException($"Balance can`t be lesser than {0}");
                        }

                        card.Balance = card.Balance - request.Sum;
                        break;
                    }

                default: { break; }
            }

            var transaction = _mapper.Map<Transaction>(request);
            transaction.PreviewBalance = balance;
            transaction.TransactionStatusId = (TransactionStatusEnum)Random.Shared.Next(1, 3);
            _transactionRepository.Create(transaction);
            _cardRepository.Update(card);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateTransactionResponse>(transaction);
        }
    }
}
