using AutoMapper;
using Domain.Entities;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed class CreateCardMapper : Profile
    {
        public CreateCardMapper() {
            CreateMap<CreateCardRequest, Card>();
            CreateMap<Card, CreateCardResponse>();
        }
    }
}
