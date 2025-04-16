using AutomobileRentalManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomobileRentalManagementAPI.Infra.DbEntitiesConfig
{
    public class UserDbConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.NavigationId);
            builder.Property(x => x.NavigationId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("text").IsRequired();
            builder.Property(x => x.Email).HasColumnType("text").IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}