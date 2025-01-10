using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.User)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Pass)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.IdPersona)
                .IsRequired();
        }
    }
}