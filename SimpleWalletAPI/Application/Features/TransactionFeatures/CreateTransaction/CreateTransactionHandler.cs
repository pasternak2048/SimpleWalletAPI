using Application.Common.Exceptions;
using Application.Common.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.Get(request.CardId, _currentUserService.UserId.GetValueOrDefault(), cancellationToken);

            if (card == null)
            {
                throw new NotFoundException("Card", request.CardId);
            }

            var balance = card.Balance;

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
            _unitOfWork.TransactionRepository.Create(transaction);
            _unitOfWork.CardRepository.Update(card);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateTransactionResponse>(transaction);
        }
    }
}
