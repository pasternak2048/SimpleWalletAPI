using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IDataContext
    {
        DbSet<Card> Cards { get; }
        DbSet<Transaction> Transactions { get; }
        DbSet<ViewTransaction> ViewTransactions { get; }
    }
}
