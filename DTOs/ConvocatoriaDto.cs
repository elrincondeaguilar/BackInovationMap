// DTOs/ConvocatoriaDto.cs
using System.ComponentModel.DataAnnotations;

namespace BackInovationMap.DTOs
{
    public class CreateConvocatoriaRequest
    {
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder 100 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La entidad es requerida")]
        [StringLength(100, ErrorMessage = "La entidad no puede exceder 100 caracteres")]
        public string Entidad { get; set; } = string.Empty;

        // ID de la empresa convocante (opcional)
        public int? CompanyId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser mayor o igual a 0")]
        public decimal? Presupuesto { get; set; }

        public List<string> Requisitos { get; set; } = new List<string>();

        // Estado inicial opcional (si no se proporciona, se calcula automáticamente)
        [RegularExpression("^(activa|cerrada|pendiente)?$", ErrorMessage = "Estado inválido. Use: activa, cerrada, pendiente o déjelo vacío")]
        public string? EstadoInicial { get; set; }

        // Control de estado alternativo
        [RegularExpression("^(activa|cerrada|pendiente)?$", ErrorMessage = "Estado inválido. Use: activa, cerrada, pendiente o déjelo vacío")]
        public string? Estado { get; set; }

        // Control manual del estado
        public bool EstadoManual { get; set; } = false;
    }

    public class UpdateConvocatoriaRequest
    {
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder 100 caracteres")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "La entidad es requerida")]
        [StringLength(100, ErrorMessage = "La entidad no puede exceder 100 caracteres")]
        public string Entidad { get; set; } = string.Empty;

        // ID de la empresa convocante (opcional)
        public int? CompanyId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El presupuesto debe ser mayor o igual a 0")]
        public decimal? Presupuesto { get; set; }

        public List<string> Requisitos { get; set; } = new List<string>();

        // Control de estado
        [RegularExpression("^(activa|cerrada|pendiente)?$", ErrorMessage = "Estado inválido. Use: activa, cerrada, pendiente o déjelo vacío")]
        public string? Estado { get; set; }

        // Control manual del estado
        public bool EstadoManual { get; set; } = false;
    }

    public class ConvocatoriaResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Entidad { get; set; } = string.Empty;
        public decimal? Presupuesto { get; set; }
        public string Estado { get; set; } = string.Empty;
        public bool EstadoManual { get; set; } = false;
        public List<string> Requisitos { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int DiasRestantes { get; set; }
        public bool EstaActiva => Estado.ToLower() == "activa";

        // Información de la empresa convocante
        public int? CompanyId { get; set; }
        public CompanyInfo? Company { get; set; }
    }

    public class CompanyInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class EstadoUpdateRequest
    {
        [Required(ErrorMessage = "El estado es requerido")]
        [RegularExpression("^(activa|cerrada|pendiente)$", ErrorMessage = "Estado inválido. Use: activa, cerrada o pendiente")]
        public string Estado { get; set; } = string.Empty;
    }
}
