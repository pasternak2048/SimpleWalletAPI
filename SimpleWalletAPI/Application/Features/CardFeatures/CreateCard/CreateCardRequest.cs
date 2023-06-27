using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed record CreateCardRequest(double BalanceLimit = 1500.00, string Name = "DefaultCard") : IRequest<CreateCardResponse>;
}
