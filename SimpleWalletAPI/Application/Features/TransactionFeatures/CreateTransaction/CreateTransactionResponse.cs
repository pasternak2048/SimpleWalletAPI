using Domain.Enums;

namespace Application.Features.TransactionFeatures.CreateTransaction
{
    public class CreateTransactionResponse
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Sum { get; set; }
        public double PreviewBalance { get; set; }
        public TransactionTypeEnum TransactionTypeId { get; set; }
        public TransactionStatusEnum TransactionStatusId { get; set; }
    }
}
