using Application.Repositories;
using Domain.Entities;
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
    }
}
