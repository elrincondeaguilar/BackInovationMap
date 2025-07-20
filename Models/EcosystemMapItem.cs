using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    /// <summary>
    /// Modelo unificado para representar cualquier entidad en el mapa del ecosistema
    /// </summary>
    public class EcosystemMapItem
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty; // "Company", "Promotor", "Articulador"
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        [StringLength(100)]
        public string? Category { get; set; }
        
        [StringLength(100)]
        public string? Sector { get; set; }
        
        [StringLength(100)]
        public string? Ciudad { get; set; }
        
        [StringLength(100)]
        public string? Departamento { get; set; }
        
        public decimal? Latitud { get; set; }
        
        public decimal? Longitud { get; set; }
        
        public string? Contacto { get; set; }
        
        public string? Enlace { get; set; }
        
        public string? LogoUrl { get; set; }
        
        // Metadatos adicionales específicos por tipo
        public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
