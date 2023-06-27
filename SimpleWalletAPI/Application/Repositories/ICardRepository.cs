using Domain.Entities;

namespace Application.Repositories
{
    public interface ICardRepository
    {
        void Create(Card entity);
    }
}
