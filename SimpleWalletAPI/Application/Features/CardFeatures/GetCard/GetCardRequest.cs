using MediatR;

namespace Application.Features.CardFeatures.GetCard
{
    public sealed record GetCardRequest(Guid CardId) : IRequest<GetCardResponse>;
}
