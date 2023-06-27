using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed record CreateCardRequest(double BalanceLimit) : IRequest<CreateCardResponse>;
}
