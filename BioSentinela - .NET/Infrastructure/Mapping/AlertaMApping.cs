using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET___BioSentinela.Domain.Entities;

namespace NET___BioSentinela.Infrastructure.Mapping
{
    public class AlertaMApping : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("Alerta");

            builder
                .HasKey("Id");

            builder
                .Property(a => a.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.Mensagem)
                .HasMaxLength(200)
                .IsRequired();

            builder
              .Property(a => a.Created)
              .HasMaxLength(20)
              .IsRequired();
        }
    }
}
