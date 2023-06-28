using Domain.Entities;

namespace Application.Repositories
{
    public interface ITransactionRepository
    {
        void Create(Transaction entity);

        Task<Transaction> Get(Guid transactionId, Guid UserId, CancellationToken cancellationToken);
        Task<List<Transaction>> GetList(Guid userId, Guid? cardId, int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<ViewTransaction> GetView(Guid transactionId, CancellationToken cancellationToken);
        Task<List<ViewTransaction>> GetListView(Guid? userId, Guid? cardId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
