using Domain.Entities;

namespace Application.Repositories
{
    public interface ITransactionRepository
    {
        void Create(Transaction entity);

        Task<Transaction> Get(Guid id, CancellationToken cancellationToken);
    }
}
