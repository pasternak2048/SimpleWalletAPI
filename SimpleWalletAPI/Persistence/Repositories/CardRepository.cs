using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {
        protected readonly DataContext Context;

        public CardRepository(DataContext context)
        {
            Context = context;
        }

        public void Create(Card entity)
        {
            Context.Add(entity);
        }

        public void Update(Card entity)
        {
            Context.Update(entity);
        }

        public async Task<Card> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<Card>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
