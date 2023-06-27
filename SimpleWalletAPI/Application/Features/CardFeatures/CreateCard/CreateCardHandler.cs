using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public class CreateCardHandler : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _realtyRepository;
        private readonly IMapper _mapper;

        public CreateCardHandler(IUnitOfWork unitOfWork, ICardRepository realtyRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _realtyRepository = realtyRepository;
            _mapper = mapper;
        }

        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);
            _realtyRepository.Create(card);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateCardResponse>(card);
        }
    }
}
