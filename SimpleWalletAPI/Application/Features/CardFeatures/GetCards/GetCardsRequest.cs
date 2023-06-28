using MediatR;

namespace Application.Features.CardFeatures.GetCards
{
    public sealed record GetCardsRequest : IRequest<List<GetCardsResponse>>;
}
