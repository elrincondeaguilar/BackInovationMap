using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PromotoresController> _logger;

        public PromotoresController(AppDbContext context, ILogger<PromotoresController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotor>>> GetPromotores()
        {
            try
            {
                var promotores = await _context.Promotores
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();
                
                _logger.LogInformation("Retrieved {Count} promotores", promotores.Count);
                return Ok(promotores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving promotores");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Promotor>> GetPromotor(int id)
        {
            try
            {
                var promotor = await _context.Promotores.FindAsync(id);
                
                if (promotor == null)
                {
                    return NotFound(new { message = $"Promotor with ID {id} not found" });
                }

                return Ok(promotor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving promotor {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Promotor>> PostPromotor(Promotor promotor)
        {
            try
            {
                promotor.CreatedAt = DateTime.UtcNow;
                promotor.UpdatedAt = DateTime.UtcNow;
                
                _context.Promotores.Add(promotor);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created new promotor with ID {Id}", promotor.Id);
                return CreatedAtAction(nameof(GetPromotor), new { id = promotor.Id }, promotor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating promotor");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotor(int id, Promotor promotor)
        {
            if (id != promotor.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            try
            {
                var existingPromotor = await _context.Promotores.FindAsync(id);
                if (existingPromotor == null)
                {
                    return NotFound(new { message = $"Promotor with ID {id} not found" });
                }

                existingPromotor.Medio = promotor.Medio;
                existingPromotor.Descripcion = promotor.Descripcion;
                existingPromotor.Enlace = promotor.Enlace;
                existingPromotor.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Updated promotor with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating promotor {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotor(int id)
        {
            try
            {
                var promotor = await _context.Promotores.FindAsync(id);
                if (promotor == null)
                {
                    return NotFound(new { message = $"Promotor with ID {id} not found" });
                }

                _context.Promotores.Remove(promotor);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted promotor with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting promotor {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            try
            {
                var count = _context.Promotores.Count();
                return Ok(new { 
                    status = "healthy",
                    count = count,
                    timestamp = DateTime.UtcNow 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for promotores");
                return StatusCode(500, new { 
                    status = "unhealthy", 
                    error = ex.Message,
                    timestamp = DateTime.UtcNow 
                });
            }
        }
    }
}
