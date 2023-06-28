namespace Application.Repositories
{
    public interface IUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }
        ICardRepository CardRepository { get; }
        Task Save(CancellationToken cancellationToken);
    }
}