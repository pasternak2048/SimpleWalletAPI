using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.TransactionFeatures.GetViewTransactions
{
    public class GetViewTransactionsHandler : IRequestHandler<GetViewTransactionsRequest, List<GetViewTransactionsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetViewTransactionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetViewTransactionsResponse>> Handle(GetViewTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.TransactionRepository.GetListView(request.UserId, request.CardId, request.PageNumber, request.PageSize, cancellationToken);
            return _mapper.Map<List<GetViewTransactionsResponse>>(transactions); 
        }
    }
}
