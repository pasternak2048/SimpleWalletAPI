using AutoMapper;
using Domain.Entities;

namespace Application.Features.CardFeatures.GetCard
{
    public class GetCardMapper : Profile
    {
        public GetCardMapper()
        {
            CreateMap<GetCardRequest, Card>();
            CreateMap<Card, GetCardResponse>();
        }
    }
}
