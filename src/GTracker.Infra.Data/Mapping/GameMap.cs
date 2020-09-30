using GTracker.Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTracker.Infra.Data.Mapping
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            builder.HasKey(ar => ar.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(c => c.AcquisicionDate)
                .IsRequired()
                .HasColumnName("dt_acquisition");

            builder.Property(c => c.Kind)
                .IsRequired()
                .HasColumnName("kind");

            builder.Property(c => c.Observation)                
                .HasColumnName("observation");
        }
    }
}