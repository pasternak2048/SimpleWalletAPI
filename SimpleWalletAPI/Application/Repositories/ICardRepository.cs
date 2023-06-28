using Domain.Entities;

namespace Application.Repositories
{
    public interface ICardRepository
    {
        void Create(Card entity);
        void Update(Card entity);

        Task<Card> Get(Guid cardId, Guid userId, CancellationToken cancellationToken);
        Task<List<Card>> GetList(Guid userId, CancellationToken cancellationToken);
    }
}
