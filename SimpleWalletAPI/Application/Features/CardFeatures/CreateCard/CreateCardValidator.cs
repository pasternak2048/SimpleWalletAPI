using FluentValidation;

namespace Application.Features.CardFeatures.CreateCard
{
    public class CreateCardValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardValidator()
        {
            RuleFor(p => p.BalanceLimit).GreaterThanOrEqualTo(0);
        }
    }
}
