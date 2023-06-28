using FluentValidation;

namespace Application.Features.TransactionFeatures.CreateTransaction
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransactionRequest>
    {
        public CreateTransactionValidator()
        {
            RuleFor(p => p.CardId).NotEmpty();
            RuleFor(p => p.TransactionTypeId).NotEmpty();
            RuleFor(p => p.Sum).NotEmpty().GreaterThanOrEqualTo(0.01);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}
