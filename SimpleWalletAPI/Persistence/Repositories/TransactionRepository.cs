﻿using Application.Repositories;
using Domain.Entities;
using MediatR;
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

        public async Task<Transaction> Get(Guid transactionId, Guid userId, CancellationToken cancellationToken)
        {
            var transactionQueryable = Context.Transactions.AsQueryable();

            var transaction = await transactionQueryable.FirstOrDefaultAsync(x => x.Id == transactionId && x.CreatedById == userId, cancellationToken);

            return transaction;
        }

        public async Task<List<Transaction>> GetList(Guid userId, Guid? cardId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var transactionsQueryable = Context.Transactions.Where(t => t.CreatedById == userId).OrderByDescending(t=>t.CreatedAt).AsQueryable();

            if (cardId != null)
            {
                transactionsQueryable = transactionsQueryable.Where(t => t.CardId == cardId);
            }

            transactionsQueryable = transactionsQueryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

            return await transactionsQueryable.ToListAsync(cancellationToken);
        }

        public async Task<ViewTransaction> GetView(Guid transactionId, CancellationToken cancellationToken)
        {
            var transaction = await Context.ViewTransactions.FirstOrDefaultAsync(t => t.Id == transactionId, cancellationToken);

            return transaction;
        }

        public async Task<List<ViewTransaction>> GetListView(Guid? userId, Guid? cardId, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var transactionsQueryable = Context.ViewTransactions.OrderByDescending(p=>p.CreatedAt).AsQueryable();

            if(userId != null)
            {
                transactionsQueryable = transactionsQueryable.Where(x => x.CreatedById == userId);
            }

            if(cardId != null)
            {
                transactionsQueryable = transactionsQueryable.Where(x => x.CardId == cardId);
            }

            transactionsQueryable = transactionsQueryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

            return await transactionsQueryable.ToListAsync(cancellationToken);
        }
    }
}
