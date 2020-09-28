using GTracker.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTracker.Infra.Data.Mapping
{
    public class LoanGameMap : IEntityTypeConfiguration<LoanGame>
    {
        public void Configure(EntityTypeBuilder<LoanGame> builder)
        {
            builder.ToTable("LoanGame");

            builder.HasKey(lg => new { lg.LoanId, lg.GameId });

            builder.Property(lg => lg.LoanId)
                .IsRequired()
                .HasColumnName("loan_id");

            builder.Property(lg => lg.GameId)
                .IsRequired()
                .HasColumnName("game_id");

            builder.Property(lg => lg.LoanStatus)
                .IsRequired()
                .HasColumnName("loan_status");

            builder.Property(c => c.DataEnd)
                .HasColumnName("dt_end");
        }
    }
}