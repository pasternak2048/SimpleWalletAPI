using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.TransactionFeatures.GetTransaction
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionRequest, GetTransactionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTransactionHandler(IMapper mapper, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTransactionResponse> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.TransactionRepository.Get(request.TransactionId, _currentUserService.UserId.GetValueOrDefault(), cancellationToken);

            if (transaction == null)
            {
                throw new NotFoundException("Transaction", request.TransactionId);
            }

            return _mapper.Map<GetTransactionResponse>(transaction);
        }
    }

}
