using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        protected readonly DataContext Context;

        public TransactionRepository(DataContext context)
        {
            Context = context;
        }

        public void Create(Transaction entity)
        {
            Context.Add(entity);
        }

        public async Task<Transaction> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<Transaction>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
