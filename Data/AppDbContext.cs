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
        
        // Nuevas tablas
        public DbSet<Promotor> Promotores { get; set; }
        public DbSet<Articulador> Articuladores { get; set; }
        
        // Tablas de relación
        public DbSet<ArticuladorCompany> ArticuladorCompanies { get; set; }
        public DbSet<ArticuladorConvocatoria> ArticuladorConvocatorias { get; set; }

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

            // Configuración para Promotor
            modelBuilder.Entity<Promotor>(entity =>
            {
                // Relación con Company (opcional)
                entity.HasOne(p => p.Company)
                    .WithMany()
                    .HasForeignKey(p => p.CompanyId)
                    .OnDelete(DeleteBehavior.SetNull);

                // Índices para mejorar rendimiento
                entity.HasIndex(e => e.Ciudad);
                entity.HasIndex(e => e.Departamento);
                entity.HasIndex(e => e.CompanyId);
            });

            // Configuración para Articulador
            modelBuilder.Entity<Articulador>(entity =>
            {
                // Índices para mejorar rendimiento
                entity.HasIndex(e => e.Ciudad);
                entity.HasIndex(e => e.Departamento);
                entity.HasIndex(e => e.Tipo);
            });

            // Configuración de relación many-to-many: ArticuladorCompany
            modelBuilder.Entity<ArticuladorCompany>(entity =>
            {
                // Clave primaria compuesta
                entity.HasKey(ac => new { ac.ArticuladorId, ac.CompanyId });

                // Relación con Articulador
                entity.HasOne(ac => ac.Articulador)
                    .WithMany(a => a.ArticuladorCompanies)
                    .HasForeignKey(ac => ac.ArticuladorId);

                // Relación con Company
                entity.HasOne(ac => ac.Company)
                    .WithMany()
                    .HasForeignKey(ac => ac.CompanyId);

                // Índices
                entity.HasIndex(e => e.TipoColaboracion);
                entity.HasIndex(e => e.Activa);
            });

            // Configuración de relación many-to-many: ArticuladorConvocatoria
            modelBuilder.Entity<ArticuladorConvocatoria>(entity =>
            {
                // Clave primaria compuesta
                entity.HasKey(ac => new { ac.ArticuladorId, ac.ConvocatoriaId });

                // Relación con Articulador
                entity.HasOne(ac => ac.Articulador)
                    .WithMany(a => a.ArticuladorConvocatorias)
                    .HasForeignKey(ac => ac.ArticuladorId);

                // Relación con Convocatoria
                entity.HasOne(ac => ac.Convocatoria)
                    .WithMany()
                    .HasForeignKey(ac => ac.ConvocatoriaId);

                // Índices
                entity.HasIndex(e => e.Rol);
                entity.HasIndex(e => e.Activo);
            });
        }
    }
}
