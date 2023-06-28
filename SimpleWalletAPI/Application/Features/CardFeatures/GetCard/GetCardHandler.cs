using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CardFeatures.GetCard
{
    public class GetCardHandler : IRequestHandler<GetCardRequest, GetCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCardHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<GetCardResponse> Handle(GetCardRequest request, CancellationToken cancellationToken)
        {
            var card =  await _unitOfWork.CardRepository.Get(request.CardId, _currentUserService.UserId.GetValueOrDefault(), cancellationToken);

            if (card == null)
            {
                throw new NotFoundException("Card", request.CardId);
            }

            return _mapper.Map<GetCardResponse>(card);
        }
    }
}
