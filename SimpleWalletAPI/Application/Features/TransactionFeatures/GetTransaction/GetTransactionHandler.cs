using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.TransactionFeatures.GetTransaction
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionRequest, GetTransactionResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<GetTransactionResponse> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.Get(request.TransactionId, cancellationToken);

            if (transaction == null)
            {
                throw new NotFoundException("Transaction", request.TransactionId);
            }

            return _mapper.Map<GetTransactionResponse>(transaction);
        }
    }

}
