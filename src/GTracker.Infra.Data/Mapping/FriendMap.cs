using GTracker.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTracker.Infra.Data.Mapping
{
    public class FriendMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friend");

            builder.HasKey(ar => ar.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasColumnName("phone");

            builder.Property(c => c.Email)
                .HasColumnName("email");
        }
    }
}