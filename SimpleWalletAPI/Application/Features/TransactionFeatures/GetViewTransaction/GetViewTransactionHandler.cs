using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.TransactionFeatures.GetViewTransaction
{
    public class GetViewTransactionHandler : IRequestHandler<GetViewTransactionRequest, GetViewTransactionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetViewTransactionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetViewTransactionResponse> Handle(GetViewTransactionRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TransactionRepository.GetView(request.TransactionId, cancellationToken);

            return _mapper.Map<GetViewTransactionResponse>(result);
        }
    }
}
