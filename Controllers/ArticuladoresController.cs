using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuladoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ArticuladoresController> _logger;

        public ArticuladoresController(AppDbContext context, ILogger<ArticuladoresController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulador>>> GetArticuladores()
        {
            try
            {
                var articuladores = await _context.Articuladores
                    .OrderByDescending(a => a.CreatedAt)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} articuladores", articuladores.Count);
                return Ok(articuladores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articuladores");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulador>> GetArticulador(int id)
        {
            try
            {
                var articulador = await _context.Articuladores.FindAsync(id);

                if (articulador == null)
                {
                    return NotFound(new { message = $"Articulador with ID {id} not found" });
                }

                return Ok(articulador);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving articulador {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Articulador>> PostArticulador(Articulador articulador)
        {
            try
            {
                articulador.CreatedAt = DateTime.UtcNow;
                articulador.UpdatedAt = DateTime.UtcNow;

                _context.Articuladores.Add(articulador);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created new articulador with ID {Id}", articulador.Id);
                return CreatedAtAction(nameof(GetArticulador), new { id = articulador.Id }, articulador);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating articulador");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulador(int id, Articulador articulador)
        {
            if (id != articulador.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            try
            {
                var existingArticulador = await _context.Articuladores.FindAsync(id);
                if (existingArticulador == null)
                {
                    return NotFound(new { message = $"Articulador with ID {id} not found" });
                }

                existingArticulador.Tipo = articulador.Tipo;
                existingArticulador.Region = articulador.Region;
                existingArticulador.Contacto = articulador.Contacto;
                existingArticulador.Ciudad = articulador.Ciudad;
                existingArticulador.Departamento = articulador.Departamento;
                existingArticulador.Latitud = articulador.Latitud;
                existingArticulador.Longitud = articulador.Longitud;
                existingArticulador.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Updated articulador with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating articulador {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulador(int id)
        {
            try
            {
                var articulador = await _context.Articuladores.FindAsync(id);
                if (articulador == null)
                {
                    return NotFound(new { message = $"Articulador with ID {id} not found" });
                }

                _context.Articuladores.Remove(articulador);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted articulador with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting articulador {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            try
            {
                var count = _context.Articuladores.Count();
                return Ok(new
                {
                    status = "healthy",
                    count = count,
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for articuladores");
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
