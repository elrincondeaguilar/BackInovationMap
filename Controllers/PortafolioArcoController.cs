using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortafolioArcoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PortafolioArcoController> _logger;

        public PortafolioArcoController(AppDbContext context, ILogger<PortafolioArcoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortafolioArco>>> GetPortafolioArco()
        {
            try
            {
                var portfolios = await _context.PortafoliosArco
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();
                
                _logger.LogInformation("Retrieved {Count} portafolio arco items", portfolios.Count);
                return Ok(portfolios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving portafolio arco");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortafolioArco>> GetPortafolioArcoItem(int id)
        {
            try
            {
                var portfolio = await _context.PortafoliosArco.FindAsync(id);
                
                if (portfolio == null)
                {
                    return NotFound(new { message = $"PortafolioArco item with ID {id} not found" });
                }

                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving portafolio arco item {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<PortafolioArco>> PostPortafolioArco(PortafolioArco portfolio)
        {
            try
            {
                portfolio.CreatedAt = DateTime.UtcNow;
                portfolio.UpdatedAt = DateTime.UtcNow;
                
                _context.PortafoliosArco.Add(portfolio);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Created new portafolio arco item with ID {Id}", portfolio.Id);
                return CreatedAtAction(nameof(GetPortafolioArcoItem), new { id = portfolio.Id }, portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating portafolio arco item");
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortafolioArco(int id, PortafolioArco portfolio)
        {
            if (id != portfolio.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            try
            {
                var existingPortfolio = await _context.PortafoliosArco.FindAsync(id);
                if (existingPortfolio == null)
                {
                    return NotFound(new { message = $"PortafolioArco item with ID {id} not found" });
                }

                existingPortfolio.Entidad = portfolio.Entidad;
                existingPortfolio.Instrumento = portfolio.Instrumento;
                existingPortfolio.TipoApoyo = portfolio.TipoApoyo;
                existingPortfolio.Objetivo = portfolio.Objetivo;
                existingPortfolio.Cobertura = portfolio.Cobertura;
                existingPortfolio.Departamento = portfolio.Departamento;
                existingPortfolio.Enlace = portfolio.Enlace;
                existingPortfolio.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Updated portafolio arco item with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating portafolio arco item {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortafolioArco(int id)
        {
            try
            {
                var portfolio = await _context.PortafoliosArco.FindAsync(id);
                if (portfolio == null)
                {
                    return NotFound(new { message = $"PortafolioArco item with ID {id} not found" });
                }

                _context.PortafoliosArco.Remove(portfolio);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted portafolio arco item with ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting portafolio arco item {Id}", id);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            try
            {
                var count = _context.PortafoliosArco.Count();
                return Ok(new { 
                    status = "healthy",
                    count = count,
                    timestamp = DateTime.UtcNow 
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for portafolio arco");
                return StatusCode(500, new { 
                    status = "unhealthy", 
                    error = ex.Message,
                    timestamp = DateTime.UtcNow 
                });
            }
        }
    }
}
