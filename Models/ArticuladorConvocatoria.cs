using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    /// <summary>
    /// Tabla de relación muchos a muchos entre Articuladores y Convocatorias
    /// Un articulador puede gestionar múltiples convocatorias
    /// Una convocatoria puede tener múltiples articuladores involucrados
    /// </summary>
    public class ArticuladorConvocatoria
    {
        public int ArticuladorId { get; set; }
        public Articulador Articulador { get; set; } = null!;
        
        public int ConvocatoriaId { get; set; }
        public Convocatoria Convocatoria { get; set; } = null!;
        
        // Metadatos de la relación
        [StringLength(100)]
        public string? Rol { get; set; }  // "Gestor", "Evaluador", "Coordinador", etc.
        
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string? Responsabilidades { get; set; }
        
        public bool Activo { get; set; } = true;
    }
}
