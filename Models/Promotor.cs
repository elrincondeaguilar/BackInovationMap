using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    public class Promotor
    {
        public int Id { get; set; }
        
        [StringLength(200)]
        public string? Medio { get; set; }
        
        public string? Descripcion { get; set; }
        
        public string? Enlace { get; set; }
        
        // Campos geográficos para visualización en mapa
        [StringLength(100)]
        public string? Ciudad { get; set; }
        
        [StringLength(100)]
        public string? Departamento { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public decimal? Longitud { get; set; }
        
        // Relaciones
        public int? CompanyId { get; set; }  // Un promotor puede estar asociado a una empresa
        public Company? Company { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
