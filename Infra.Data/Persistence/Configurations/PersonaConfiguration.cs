using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nombres)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Apellidos)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.NumeroIdentificacion)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.TipoIdentificacion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
