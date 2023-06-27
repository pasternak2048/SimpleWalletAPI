using FluentValidation;

namespace Application.Features.CardFeatures.CreateCard
{
    public sealed class CreateCardMapper : AbstractValidator<CreateCardRequest>
    {
        public CreateCardMapper() {
            RuleFor(p => p.BalanceLimit).GreaterThanOrEqualTo(0);
        }
    }
}
