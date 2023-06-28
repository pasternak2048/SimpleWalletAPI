using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed record CreateCardRequest(string Name) : IRequest<CreateCardResponse>;
}
