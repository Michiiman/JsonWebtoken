using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("user");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(255);

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .IsRequired()
            .HasMaxLength(100);

            builder
            .HasMany(p=>p.Rols)
            .WithMany(p=>p.Users)
            .UsingEntity<UserRol>(
            j=>j
                .HasOne(pt=>pt.Rol)
                .WithMany(t=>t.UsersRols)
                .HasForeignKey(pt=>pt.RolIdFk),
            j => j
                .HasOne(pt => pt.User)
                .WithMany(t => t.UsersRols)
                .HasForeignKey(pt => pt.UserIdFk),
            j => 
            {
                j.ToTable("userRol");
                j.HasKey(t => new { t.UserIdFk, t.RolIdFk});
            });
           
        }
    }
}