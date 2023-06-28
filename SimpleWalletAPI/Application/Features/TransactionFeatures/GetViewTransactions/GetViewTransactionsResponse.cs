using Domain.Enums;

namespace Application.Features.TransactionFeatures.GetViewTransactions
{
    public class GetViewTransactionsResponse
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Sum { get; set; }
        public double PreviewBalance { get; set; }
        public TransactionTypeEnum TransactionTypeId { get; set; }
        public TransactionStatusEnum TransactionStatusId { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
