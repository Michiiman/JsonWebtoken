using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Rol");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.Nombre)
            .HasColumnName("nombre")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(50);
            
        }
    }
}