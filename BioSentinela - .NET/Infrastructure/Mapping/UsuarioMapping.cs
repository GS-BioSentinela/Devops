using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET___BioSentinela.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NET___BioSentinela.Infrastructure.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder
                .HasKey("Id");

            builder
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property (u => u.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(u => u.Created)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
