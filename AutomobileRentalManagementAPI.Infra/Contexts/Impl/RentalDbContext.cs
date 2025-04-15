using AutomobileRentalManagementAPI.Infra.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace AutomobileRentalManagementAPI.Infra.Contexts.Impl
{
    public class RentalDbContext(
    DbContextOptions<RentalDbContext> options)
    : DbContext(options)
    {
        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalDbContext).Assembly);
        }
    }
}
