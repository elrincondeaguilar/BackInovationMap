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
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
