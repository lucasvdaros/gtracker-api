using GTracker.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTracker.Infra.Data.Mapping
{
    public class LoanMap : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");

            builder.HasKey(ar => ar.Id);

            builder.Property(c => c.FriendId)
                .IsRequired()
                .HasColumnName("friend_id");

            builder.Property(c => c.DateStart)
                .IsRequired()
                .HasColumnName("dt_start");

            builder.Property(c => c.Observation)
                .HasColumnName("observation");
        }
    }
}