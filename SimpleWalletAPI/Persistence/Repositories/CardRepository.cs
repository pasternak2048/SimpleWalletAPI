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

        public async Task<Card> Get(Guid cardId, Guid? userId, CancellationToken cancellationToken)
        {
            var cardQueryable = Context.Cards.AsNoTracking().AsQueryable();

            if (userId != null)
            {
                cardQueryable = cardQueryable.Where(x => x.CreatedById == userId);
            }

            var card = await cardQueryable.FirstOrDefaultAsync(x => x.Id == cardId, cancellationToken);

            return card;
        }
    }
}
