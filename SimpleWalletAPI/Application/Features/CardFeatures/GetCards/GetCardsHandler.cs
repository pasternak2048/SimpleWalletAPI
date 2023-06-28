﻿using Application.Common.Interfaces;
using Application.Features.TransactionFeatures.GetTransactions;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CardFeatures.GetCards
{
    public class GetCardsHandler : IRequestHandler<GetCardsRequest, List<GetCardsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCardsHandler(IUnitOfWork unitOfWork, ICardRepository cardRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<GetCardsResponse>> Handle(GetCardsRequest request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetList(_currentUserService.UserId.GetValueOrDefault(), cancellationToken);

            return _mapper.Map<List<GetCardsResponse>>(cards);
        }
    }
}