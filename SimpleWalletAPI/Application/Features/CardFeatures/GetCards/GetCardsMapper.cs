using AutoMapper;
using Domain.Entities;

namespace Application.Features.CardFeatures.GetCards
{
    public class GetCardsMapper : Profile
    {
        public GetCardsMapper() {
            CreateMap<GetCardsRequest, Card>();
            CreateMap<Card, GetCardsResponse>();
        }
    }
}
