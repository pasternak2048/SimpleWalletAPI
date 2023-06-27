using Domain.Common;

namespace Domain.Entities
{
    public class Card : AuditableEntity
    {
        public Card() {
            Transactions = new HashSet<Transaction>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double BalanceLimit { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
