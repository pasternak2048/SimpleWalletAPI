using Application.Common.Interfaces;
using Application.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.TransactionFeatures.GetTransactions
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsRequest, List<GetTransactionsResponse>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionsHandler(ITransactionRepository transactionRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<GetTransactionsResponse>> Handle(GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetList(_currentUserService.UserId.GetValueOrDefault(), request.CardId, request.PageNumber, request.PageSize, cancellationToken);

            return _mapper.Map<List<GetTransactionsResponse>>(transactions);
        }
    }
}
