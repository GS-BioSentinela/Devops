using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET___BioSentinela.Domain.Entities;

namespace NET___BioSentinela.Infrastructure.Mapping
{
    public class SensorMapping : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("Sensor");

            builder
                .HasKey("Id");

            builder
                .Property(s => s.Tipo)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property (s => s.Localizacao)
                .HasMaxLength(150)
                .IsRequired();

            builder
              .Property(s => s.Created)
              .HasMaxLength(20)
              .IsRequired();
        }
    }
}
