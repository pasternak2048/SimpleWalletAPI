using Domain.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Persistence.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditableEntityInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new())
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries<AuditableEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = _currentUserService.UserId.Value;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedById = _currentUserService.UserId;
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        break;
                }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
