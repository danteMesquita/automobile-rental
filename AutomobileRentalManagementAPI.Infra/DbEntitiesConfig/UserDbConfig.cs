using AutomobileRentalManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomobileRentalManagementAPI.Infra.DbEntitiesConfig
{
    public class UserDbConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(nameof(UserEntity));

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasKey(x => x.NavigationId);
            builder.Property(x => x.NavigationId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnType("text").IsRequired();
            builder.Property(x => x.Email).HasColumnType("text").IsRequired();
        }
    }
}