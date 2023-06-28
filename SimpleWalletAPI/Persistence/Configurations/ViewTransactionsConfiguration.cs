﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ViewTransactionsConfiguration : IEntityTypeConfiguration<ViewTransaction>
    {
        public void Configure(EntityTypeBuilder<ViewTransaction> builder)
        {
            builder.ToView("ViewTransactions");
        }
    }
}
