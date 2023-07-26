using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PiePOS.Domain.Common;
using PiePOS.Domain.StoreDomains.Users;

namespace PiePOS.Persistence.DbContexts
{
    public class StoreDbContext : IdentityDbContext<AppUser>
    {
        private IDbContextTransaction _currentTransaction;
        public StoreDbContext(DbContextOptions<StoreDbContext> dbContextOptions) : base(dbContextOptions)
        {
            //try
            //{
            //    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            //    if (databaseCreator != null)
            //    {
            //        if (!databaseCreator.CanConnect()) databaseCreator.Create();
            //        if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.EnableDetailedErrors();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void AddAuditInfo()
        {
            var timestamp = DateTime.UtcNow;


            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {

                if (entry.State == EntityState.Added)
                {

                    ((BaseEntity)entry.Entity).CreatedDate = timestamp;
                }
                else
                {
                    ((BaseEntity)entry.Entity).UpdatedDate = timestamp;
                    ((BaseEntity)entry.Entity).CreatedDate = (DateTime?)entry.Property("CreatedDate").OriginalValue;
                }

            }
        }

    }
}
