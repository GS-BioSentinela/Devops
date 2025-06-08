using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET___BioSentinela.Domain.Entities;

namespace NET___BioSentinela.Infrastructure.Mapping
{
    public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.ToTable("Regiao");

            builder
                .HasKey("Id");

            builder
                .Property(r => r.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(r => r.Bioma)
                .HasMaxLength(200);

        }
    }
}
