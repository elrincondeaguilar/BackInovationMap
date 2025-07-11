using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;
using BackInovationMap.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvocatoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConvocatoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            var convocatorias = _context.Convocatorias
                .Include(c => c.Company)
                .OrderByDescending(c => c.CreatedAt)
                .ToList()
                .Select(c => MapToResponse(c))
                .ToList();
            return Ok(convocatorias);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var convocatoria = _context.Convocatorias
                .Include(c => c.Company)
                .FirstOrDefault(c => c.Id == id);
            if (convocatoria == null)
            {
                return NotFound($"Convocatoria with ID {id} not found.");
            }
            return Ok(MapToResponse(convocatoria));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] CreateConvocatoriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar fechas
            if (request.FechaInicio >= request.FechaFin)
            {
                return BadRequest("La fecha de inicio debe ser anterior a la fecha de fin.");
            }

            // Validar que la empresa existe si se proporciona CompanyId
            if (request.CompanyId.HasValue)
            {
                var companyExists = _context.Companies.Any(c => c.Id == request.CompanyId.Value);
                if (!companyExists)
                {
                    return BadRequest($"La empresa con ID {request.CompanyId.Value} no existe.");
                }
            }

            var convocatoria = new Convocatoria
            {
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Categoria = request.Categoria,
                Entidad = request.Entidad,
                CompanyId = request.CompanyId,
                Presupuesto = request.Presupuesto,
                Requisitos = request.Requisitos ?? new List<string>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Establecer estado: manual si se proporciona, automático si no
            if (!string.IsNullOrEmpty(request.EstadoInicial))
            {
                EstablecerEstado(convocatoria, true, request.EstadoInicial);
            }
            else if (request.EstadoManual && !string.IsNullOrEmpty(request.Estado))
            {
                EstablecerEstado(convocatoria, true, request.Estado);
            }
            else
            {
                EstablecerEstado(convocatoria);
            }

            _context.Convocatorias.Add(convocatoria);
            _context.SaveChanges();

            // Recargar con la empresa para la respuesta
            var savedConvocatoria = _context.Convocatorias
                .Include(c => c.Company)
                .FirstOrDefault(c => c.Id == convocatoria.Id);

            return CreatedAtAction(nameof(GetById), new { id = convocatoria.Id }, MapToResponse(savedConvocatoria!));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult Put(int id, [FromBody] UpdateConvocatoriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingConvocatoria = _context.Convocatorias.Find(id);
            if (existingConvocatoria == null)
            {
                return NotFound($"Convocatoria with ID {id} not found.");
            }

            // Validar fechas
            if (request.FechaInicio >= request.FechaFin)
            {
                return BadRequest("La fecha de inicio debe ser anterior a la fecha de fin.");
            }

            // Validar que la empresa existe si se proporciona CompanyId
            if (request.CompanyId.HasValue)
            {
                var companyExists = _context.Companies.Any(c => c.Id == request.CompanyId.Value);
                if (!companyExists)
                {
                    return BadRequest($"La empresa con ID {request.CompanyId.Value} no existe.");
                }
            }

            // Actualizar campos
            existingConvocatoria.Titulo = request.Titulo;
            existingConvocatoria.Descripcion = request.Descripcion;
            existingConvocatoria.FechaInicio = request.FechaInicio;
            existingConvocatoria.FechaFin = request.FechaFin;
            existingConvocatoria.Categoria = request.Categoria;
            existingConvocatoria.Entidad = request.Entidad;
            existingConvocatoria.CompanyId = request.CompanyId;
            existingConvocatoria.Presupuesto = request.Presupuesto;
            existingConvocatoria.Requisitos = request.Requisitos ?? new List<string>();
            existingConvocatoria.UpdatedAt = DateTime.UtcNow;

            // Manejar estado: manual si se proporciona, automático si no
            if (request.EstadoManual && !string.IsNullOrEmpty(request.Estado))
            {
                EstablecerEstado(existingConvocatoria, true, request.Estado);
            }
            else if (!request.EstadoManual)
            {
                EstablecerEstado(existingConvocatoria);
            }
            // Si EstadoManual es true pero no se proporciona Estado, mantener el estado actual

            _context.Convocatorias.Update(existingConvocatoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var convocatoria = _context.Convocatorias.Find(id);
            if (convocatoria == null)
            {
                return NotFound($"Convocatoria with ID {id} not found.");
            }

            _context.Convocatorias.Remove(convocatoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("categoria/{categoria}")]
        [ProducesResponseType(200)]
        public IActionResult GetByCategoria(string categoria)
        {
            var convocatorias = _context.Convocatorias
                .Include(c => c.Company)
                .Where(c => c.Categoria.ToLower().Contains(categoria.ToLower()))
                .OrderByDescending(c => c.CreatedAt)
                .ToList()
                .Select(c => MapToResponse(c))
                .ToList();
            return Ok(convocatorias);
        }

        [HttpGet("estado/{estado}")]
        [ProducesResponseType(200)]
        public IActionResult GetByEstado(string estado)
        {
            var convocatorias = _context.Convocatorias
                .Include(c => c.Company)
                .Where(c => c.Estado.ToLower() == estado.ToLower())
                .OrderByDescending(c => c.CreatedAt)
                .ToList()
                .Select(c => MapToResponse(c))
                .ToList();
            return Ok(convocatorias);
        }

        [HttpGet("activas")]
        [ProducesResponseType(200)]
        public IActionResult GetActivas()
        {
            var now = DateTime.UtcNow;
            var convocatorias = _context.Convocatorias
                .Include(c => c.Company)
                .Where(c => c.FechaInicio <= now && c.FechaFin >= now)
                .OrderByDescending(c => c.CreatedAt)
                .ToList()
                .Select(c => MapToResponse(c))
                .ToList();
            return Ok(convocatorias);
        }

        [HttpPut("{id}/estado")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateEstado(int id, [FromBody] EstadoUpdateRequest request)
        {
            var convocatoria = _context.Convocatorias.Find(id);
            if (convocatoria == null)
            {
                return NotFound($"Convocatoria with ID {id} not found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Establecer estado manualmente
            EstablecerEstado(convocatoria, true, request.Estado);
            convocatoria.UpdatedAt = DateTime.UtcNow;

            _context.Convocatorias.Update(convocatoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/estado/automatico")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult RestablecerEstadoAutomatico(int id)
        {
            var convocatoria = _context.Convocatorias.Find(id);
            if (convocatoria == null)
            {
                return NotFound($"Convocatoria with ID {id} not found.");
            }

            // Restablecer estado automático basado en fechas
            convocatoria.EstadoManual = false;
            EstablecerEstado(convocatoria);
            convocatoria.UpdatedAt = DateTime.UtcNow;

            _context.Convocatorias.Update(convocatoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("empresas-disponibles")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetEmpresasDisponibles()
        {
            try
            {
                var empresas = _context.Companies
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Sector,
                        c.LogoUrl,
                        c.Description
                    })
                    .OrderBy(c => c.Name)
                    .ToList();

                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Error retrieving companies",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow
                });
            }
        }

        [HttpGet("por-empresa/{companyId}")]
        [ProducesResponseType(200)]
        public IActionResult GetByEmpresa(int companyId)
        {
            var convocatorias = _context.Convocatorias
                .Include(c => c.Company)
                .Where(c => c.CompanyId == companyId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList()
                .Select(c => MapToResponse(c))
                .ToList();
            return Ok(convocatorias);
        }

        // Método helper para determinar el estado automático basado en fechas
        private static string DeterminarEstadoAutomatico(DateTime fechaInicio, DateTime fechaFin)
        {
            var now = DateTime.UtcNow;
            if (fechaInicio > now)
            {
                return "pendiente";
            }
            else if (fechaFin < now)
            {
                return "cerrada";
            }
            else
            {
                return "activa";
            }
        }

        // Método helper para establecer el estado considerando la configuración manual
        private static void EstablecerEstado(Convocatoria convocatoria, bool esEstadoManual = false, string estadoManual = "")
        {
            if (esEstadoManual && !string.IsNullOrEmpty(estadoManual))
            {
                // Estado establecido manualmente
                convocatoria.Estado = estadoManual.ToLower();
                convocatoria.EstadoManual = true;
            }
            else if (!convocatoria.EstadoManual)
            {
                // Solo actualizar automáticamente si no fue establecido manualmente
                convocatoria.Estado = DeterminarEstadoAutomatico(convocatoria.FechaInicio, convocatoria.FechaFin);
            }
            // Si EstadoManual es true, mantener el estado actual sin cambios
        }

        // Método helper para mapear entidad a DTO de respuesta
        private static ConvocatoriaResponse MapToResponse(Convocatoria convocatoria)
        {
            var now = DateTime.UtcNow;
            var diasRestantes = convocatoria.FechaFin > now
                ? (int)(convocatoria.FechaFin - now).TotalDays
                : 0;

            return new ConvocatoriaResponse
            {
                Id = convocatoria.Id,
                Titulo = convocatoria.Titulo,
                Descripcion = convocatoria.Descripcion,
                FechaInicio = convocatoria.FechaInicio,
                FechaFin = convocatoria.FechaFin,
                Categoria = convocatoria.Categoria,
                Entidad = convocatoria.Entidad,
                CompanyId = convocatoria.CompanyId,
                Company = convocatoria.Company != null ? new CompanyInfo
                {
                    Id = convocatoria.Company.Id,
                    Name = convocatoria.Company.Name,
                    Sector = convocatoria.Company.Sector,
                    LogoUrl = convocatoria.Company.LogoUrl,
                    Description = convocatoria.Company.Description
                } : null,
                Presupuesto = convocatoria.Presupuesto,
                Estado = convocatoria.Estado,
                EstadoManual = convocatoria.EstadoManual,
                Requisitos = convocatoria.Requisitos,
                CreatedAt = convocatoria.CreatedAt,
                UpdatedAt = convocatoria.UpdatedAt,
                DiasRestantes = diasRestantes
            };
        }
    }
}
