using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    public class PortafolioArco
    {
        public int Id { get; set; }
        
        public int? Anio { get; set; }
        
        [StringLength(200)]
        public string? Entidad { get; set; }
        
        [StringLength(200)]
        public string? Instrumento { get; set; }
        
        [StringLength(200)]
        public string? TipoApoyo { get; set; }
        
        public string? Objetivo { get; set; }
        
        [StringLength(200)]
        public string? Cobertura { get; set; }
        
        [StringLength(100)]
        public string? Departamento { get; set; }
        
        public string? Enlace { get; set; }
        
        // Campos geográficos para visualización en mapa
        [StringLength(100)]
        public string? Ciudad { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public decimal? Longitud { get; set; }
        
        // Relaciones - Los instrumentos ARCO pueden estar relacionados con convocatorias
        public int? ConvocatoriaId { get; set; }  // Instrumento puede derivar en convocatoria
        public Convocatoria? Convocatoria { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
