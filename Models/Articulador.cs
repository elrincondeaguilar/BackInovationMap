using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    public class Articulador
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Tipo { get; set; }
        
        [StringLength(100)]
        public string? Region { get; set; }
        
        public string? Contacto { get; set; }
        
        // Campos geográficos para visualización en mapa
        [StringLength(100)]
        public string? Ciudad { get; set; }
        
        [StringLength(100)]
        public string? Departamento { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public decimal? Longitud { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
