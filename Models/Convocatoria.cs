using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.Models
{
    public class Convocatoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Entidad { get; set; } = string.Empty;

        // Relación con Company - Empresa convocante (opcional)
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public decimal? Presupuesto { get; set; }

        [StringLength(50)]
        public string Estado { get; set; } = "activa"; // activa, cerrada, pendiente

        // Indica si el estado fue establecido manualmente por un administrador
        public bool EstadoManual { get; set; } = false;

        public List<string> Requisitos { get; set; } = new List<string>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
