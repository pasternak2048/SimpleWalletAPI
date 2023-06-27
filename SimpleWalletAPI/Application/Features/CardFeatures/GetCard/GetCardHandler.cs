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
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCardHandler(IUnitOfWork unitOfWork, ICardRepository cardRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<GetCardResponse> Handle(GetCardRequest request, CancellationToken cancellationToken)
        {
            var card =  await _cardRepository.Get(request.CardId, _currentUserService.UserId, cancellationToken);

            if (card == null)
            {
                throw new NotFoundException("Card", request.CardId);
            }

            return _mapper.Map<GetCardResponse>(card);
        }
    }
}
