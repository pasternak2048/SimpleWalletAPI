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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionsHandler(IMapper mapper, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetTransactionsResponse>> Handle(GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.TransactionRepository.GetList(_currentUserService.UserId.GetValueOrDefault(), request.CardId, request.PageNumber, request.PageSize, cancellationToken);

            return _mapper.Map<List<GetTransactionsResponse>>(transactions);
        }
    }
}
