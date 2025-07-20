using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcosystemRelationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EcosystemRelationsController> _logger;

        public EcosystemRelationsController(AppDbContext context, ILogger<EcosystemRelationsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtener todas las relaciones entre articuladores y empresas
        /// </summary>
        [HttpGet("articulador-companies")]
        public async Task<ActionResult<IEnumerable<object>>> GetArticuladorCompanyRelations()
        {
            try
            {
                var relations = await _context.ArticuladorCompanies
                    .Include(ac => ac.Articulador)
                    .Include(ac => ac.Company)
                    .Select(ac => new
                    {
                        articuladorId = ac.ArticuladorId,
                        articuladorNombre = ac.Articulador.Nombre,
                        companyId = ac.CompanyId,
                        companyNombre = ac.Company.Name,
                        tipoColaboracion = ac.TipoColaboracion,
                        fechaInicio = ac.FechaInicio,
                        fechaFin = ac.FechaFin,
                        activa = ac.Activa,
                        notas = ac.Notas
                    })
                    .ToListAsync();

                return Ok(relations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articulador-company relations");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Crear relación entre articulador y empresa
        /// </summary>
        [HttpPost("articulador-company")]
        public async Task<IActionResult> CreateArticuladorCompanyRelation(
            [FromBody] ArticuladorCompanyDto dto)
        {
            try
            {
                var relation = new ArticuladorCompany
                {
                    ArticuladorId = dto.ArticuladorId,
                    CompanyId = dto.CompanyId,
                    TipoColaboracion = dto.TipoColaboracion,
                    FechaInicio = dto.FechaInicio ?? DateTime.UtcNow,
                    Notas = dto.Notas,
                    Activa = true
                };

                _context.ArticuladorCompanies.Add(relation);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Relación creada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating articulador-company relation");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtener empresas asociadas a un articulador específico
        /// </summary>
        [HttpGet("articulador/{articuladorId}/companies")]
        public async Task<ActionResult<IEnumerable<object>>> GetCompaniesByArticulador(int articuladorId)
        {
            try
            {
                var companies = await _context.ArticuladorCompanies
                    .Where(ac => ac.ArticuladorId == articuladorId && ac.Activa)
                    .Include(ac => ac.Company)
                    .Select(ac => new
                    {
                        id = ac.Company.Id,
                        name = ac.Company.Name,
                        sector = ac.Company.Sector,
                        tipoColaboracion = ac.TipoColaboracion,
                        fechaInicio = ac.FechaInicio,
                        notas = ac.Notas
                    })
                    .ToListAsync();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving companies for articulador {ArticuladorId}", articuladorId);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtener articuladores asociados a una empresa específica
        /// </summary>
        [HttpGet("company/{companyId}/articuladores")]
        public async Task<ActionResult<IEnumerable<object>>> GetArticuladoresByCompany(int companyId)
        {
            try
            {
                var articuladores = await _context.ArticuladorCompanies
                    .Where(ac => ac.CompanyId == companyId && ac.Activa)
                    .Include(ac => ac.Articulador)
                    .Select(ac => new
                    {
                        id = ac.Articulador.Id,
                        nombre = ac.Articulador.Nombre,
                        tipo = ac.Articulador.Tipo,
                        tipoColaboracion = ac.TipoColaboracion,
                        fechaInicio = ac.FechaInicio,
                        notas = ac.Notas
                    })
                    .ToListAsync();

                return Ok(articuladores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articuladores for company {CompanyId}", companyId);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Terminar relación entre articulador y empresa
        /// </summary>
        [HttpPut("articulador-company/{articuladorId}/{companyId}/deactivate")]
        public async Task<IActionResult> DeactivateArticuladorCompanyRelation(int articuladorId, int companyId)
        {
            try
            {
                var relation = await _context.ArticuladorCompanies
                    .FirstOrDefaultAsync(ac => ac.ArticuladorId == articuladorId && ac.CompanyId == companyId);

                if (relation == null)
                {
                    return NotFound(new { message = "Relación no encontrada" });
                }

                relation.Activa = false;
                relation.FechaFin = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Relación desactivada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deactivating articulador-company relation");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }
    }

    // DTOs para las requests
    public class ArticuladorCompanyDto
    {
        public int ArticuladorId { get; set; }
        public int CompanyId { get; set; }
        public string? TipoColaboracion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string? Notas { get; set; }
    }
}
