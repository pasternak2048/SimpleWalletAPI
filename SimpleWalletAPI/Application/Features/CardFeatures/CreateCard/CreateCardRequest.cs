using MediatR;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed class CreateCardRequest : IRequest<CreateCardResponse>
    {
        public string Name { get; set; }
    }
}
