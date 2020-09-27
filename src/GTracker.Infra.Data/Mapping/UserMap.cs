using GTracker.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTracker.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("SystemUser");

            builder.HasKey(ar => ar.Id);

            builder.Property(c => c.Active)
                .IsRequired()
                .HasColumnName("active");

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnName("login");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("password");
        }
    }
}