using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    /// <summary>
    /// Tabla de relación muchos a muchos entre Articuladores y Companies
    /// Un articulador puede trabajar con múltiples empresas
    /// Una empresa puede trabajar con múltiples articuladores
    /// </summary>
    public class ArticuladorCompany
    {
        public int ArticuladorId { get; set; }
        public Articulador Articulador { get; set; } = null!;
        
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        
        // Metadatos de la relación
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
        public DateTime? FechaFin { get; set; }
        
        [StringLength(500)]
        public string? Notas { get; set; }
        
        [StringLength(100)]
        public string? TipoColaboracion { get; set; }  // "Asesoría", "Mentoría", "Incubación", etc.
        
        public bool Activa { get; set; } = true;
    }
}
