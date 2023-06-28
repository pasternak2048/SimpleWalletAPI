﻿using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public class CreateCardHandler : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateCardHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var card = _mapper.Map<Card>(request);
            _unitOfWork.CardRepository.Create(card);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateCardResponse>(card);
        }
    }
}
