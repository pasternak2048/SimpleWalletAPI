using Domain.Entities;

namespace Application.Repositories
{
    public interface ITransactionRepository
    {
        void Create(Transaction entity);

        Task<Transaction> Get(Guid transactionId, Guid UserId, CancellationToken cancellationToken);
        Task<List<Transaction>> GetList(Guid UserId, Guid? CardId, int PageNumber, int PageSize, CancellationToken cancellationToken);
    }
}
