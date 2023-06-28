using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.TransactionFeatures.GetTransaction
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionRequest, GetTransactionResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<GetTransactionResponse> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.Get(request.TransactionId, _currentUserService.UserId.GetValueOrDefault(), cancellationToken);

            if (transaction == null)
            {
                throw new NotFoundException("Transaction", request.TransactionId);
            }

            return _mapper.Map<GetTransactionResponse>(transaction);
        }
    }

}
