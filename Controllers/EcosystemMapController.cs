using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Models;
using BackInovationMap.Services;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcosystemMapController : ControllerBase
    {
        private readonly IEcosystemMapService _ecosystemMapService;
        private readonly ILogger<EcosystemMapController> _logger;

        public EcosystemMapController(IEcosystemMapService ecosystemMapService, ILogger<EcosystemMapController> logger)
        {
            _ecosystemMapService = ecosystemMapService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los elementos del ecosistema para visualizar en el mapa
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EcosystemMapItem>>> GetEcosystemMap()
        {
            try
            {
                var items = await _ecosystemMapService.GetAllEcosystemItemsAsync();
                _logger.LogInformation("Retrieved {Count} ecosystem map items", items.Count);
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ecosystem map");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtiene elementos del ecosistema filtrados para el mapa
        /// </summary>
        /// <param name="types">Tipos de entidades a incluir (Company, Promotor, Articulador, PortafolioArco)</param>
        /// <param name="departamento">Filtrar por departamento</param>
        /// <param name="ciudad">Filtrar por ciudad</param>
        /// <param name="sector">Filtrar por sector (solo aplica a Companies)</param>
        /// <param name="categoria">Filtrar por categoría</param>
        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<EcosystemMapItem>>> GetFilteredEcosystemMap(
            [FromQuery] List<string>? types = null,
            [FromQuery] string? departamento = null,
            [FromQuery] string? ciudad = null,
            [FromQuery] string? sector = null,
            [FromQuery] string? categoria = null)
        {
            try
            {
                var items = await _ecosystemMapService.GetFilteredEcosystemItemsAsync(
                    types, departamento, ciudad, sector, categoria);

                _logger.LogInformation("Retrieved {Count} filtered ecosystem map items with filters: types={Types}, departamento={Departamento}, ciudad={Ciudad}, sector={Sector}, categoria={Categoria}",
                    items.Count,
                    types != null ? string.Join(",", types) : "all",
                    departamento ?? "all",
                    ciudad ?? "all",
                    sector ?? "all",
                    categoria ?? "all");

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving filtered ecosystem map");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtiene las opciones disponibles para filtros
        /// </summary>
        [HttpGet("filter-options")]
        public async Task<ActionResult<object>> GetFilterOptions()
        {
            try
            {
                var allItems = await _ecosystemMapService.GetAllEcosystemItemsAsync();

                var filterOptions = new
                {
                    types = new[] { "Company", "Promotor", "Articulador", "PortafolioArco" },
                    departamentos = allItems
                        .Where(i => !string.IsNullOrEmpty(i.Departamento))
                        .Select(i => i.Departamento!)
                        .Distinct()
                        .OrderBy(d => d)
                        .ToList(),
                    ciudades = allItems
                        .Where(i => !string.IsNullOrEmpty(i.Ciudad))
                        .Select(i => i.Ciudad!)
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList(),
                    sectores = allItems
                        .Where(i => !string.IsNullOrEmpty(i.Sector))
                        .Select(i => i.Sector!)
                        .Distinct()
                        .OrderBy(s => s)
                        .ToList(),
                    categorias = allItems
                        .Where(i => !string.IsNullOrEmpty(i.Category))
                        .Select(i => i.Category!)
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList()
                };

                return Ok(filterOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving filter options");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtiene estadísticas del ecosistema
        /// </summary>
        [HttpGet("stats")]
        public async Task<ActionResult<object>> GetEcosystemStats()
        {
            try
            {
                var allItems = await _ecosystemMapService.GetAllEcosystemItemsAsync();

                var stats = new
                {
                    total = allItems.Count,
                    byType = allItems
                        .GroupBy(i => i.Type)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    byDepartamento = allItems
                        .Where(i => !string.IsNullOrEmpty(i.Departamento))
                        .GroupBy(i => i.Departamento!)
                        .ToDictionary(g => g.Key, g => g.Count()),
                    withCoordinates = allItems.Count(i => i.Latitud.HasValue && i.Longitud.HasValue),
                    withoutCoordinates = allItems.Count(i => !i.Latitud.HasValue || !i.Longitud.HasValue)
                };

                return Ok(stats);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ecosystem stats");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Health check para el servicio del mapa
        /// </summary>
        [HttpGet("health")]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                var items = await _ecosystemMapService.GetAllEcosystemItemsAsync();
                return Ok(new
                {
                    status = "healthy",
                    totalItems = items.Count,
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for ecosystem map");
                return StatusCode(500, new
                {
                    status = "unhealthy",
                    error = ex.Message,
                    timestamp = DateTime.UtcNow
                });
            }
        }
    }
}
