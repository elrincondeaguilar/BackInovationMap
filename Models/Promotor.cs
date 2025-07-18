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
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
