using Microsoft.EntityFrameworkCore;
using BackInovationMap.Models;
using System.Text.Json;

namespace BackInovationMap.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Convocatoria> Convocatorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para el modelo Convocatoria
            modelBuilder.Entity<Convocatoria>(entity =>
            {
                // Configurar la conversión de la lista de requisitos a JSON
                entity.Property(e => e.Requisitos)
                    .HasConversion(
                        v => string.Join(";", v),
                        v => string.IsNullOrEmpty(v) ? new List<string>() : v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .HasColumnType("text");

                // Configurar comparador de valores para la lista de requisitos
                entity.Property(e => e.Requisitos)
                    .Metadata.SetValueComparer(
                        new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                            (c1, c2) => (c1 == null && c2 == null) || (c1 != null && c2 != null && c1.SequenceEqual(c2)),
                            c => c == null ? 0 : c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c == null ? new List<string>() : c.ToList()
                        )
                    );

                // Configurar el campo presupuesto
                entity.Property(e => e.Presupuesto)
                    .HasColumnType("decimal(18,2)");

                // Configurar la relación con Company
                entity.HasOne(c => c.Company)
                    .WithMany()
                    .HasForeignKey(c => c.CompanyId)
                    .OnDelete(DeleteBehavior.SetNull);

                // Configurar índices para mejorar rendimiento
                entity.HasIndex(e => e.Estado);
                entity.HasIndex(e => e.Categoria);
                entity.HasIndex(e => e.FechaInicio);
                entity.HasIndex(e => e.FechaFin);
                entity.HasIndex(e => e.CompanyId);
            });

            // Configuración para el modelo Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                // Email único
                entity.HasIndex(e => e.Email).IsUnique();

                // Índices para mejorar rendimiento
                entity.HasIndex(e => e.Rol);
                entity.HasIndex(e => e.IsActive);
                entity.HasIndex(e => e.CreatedAt);
            });
        }
    }
}
