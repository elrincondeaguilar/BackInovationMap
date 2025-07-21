using BackInovationMap.Data;
using BackInovationMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BackInovationMap.Services
{
    public interface IEcosystemMapService
    {
        Task<List<EcosystemMapItem>> GetAllEcosystemItemsAsync();
        Task<List<EcosystemMapItem>> GetFilteredEcosystemItemsAsync(
            List<string>? types = null,
            string? departamento = null,
            string? ciudad = null,
            string? sector = null,
            string? categoria = null
        );
    }

    public class EcosystemMapService : IEcosystemMapService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EcosystemMapService> _logger;

        public EcosystemMapService(AppDbContext context, ILogger<EcosystemMapService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<EcosystemMapItem>> GetAllEcosystemItemsAsync()
        {
            return await GetFilteredEcosystemItemsAsync();
        }

        public async Task<List<EcosystemMapItem>> GetFilteredEcosystemItemsAsync(
            List<string>? types = null,
            string? departamento = null,
            string? ciudad = null,
            string? sector = null,
            string? categoria = null)
        {
            var items = new List<EcosystemMapItem>();

            try
            {
                // Incluir Companies si no se especifica filtro de tipo o si se incluye "Company"
                if (types == null || types.Contains("Company", StringComparer.OrdinalIgnoreCase))
                {
                    var companies = await _context.Companies
                        .Where(c =>
                            (departamento == null || c.Department == departamento) &&
                            (ciudad == null || c.Ciudad == ciudad) &&
                            (sector == null || c.Sector == sector) &&
                            c.Latitud != null && c.Longitud != null)
                        .ToListAsync();

                    items.AddRange(companies.Select(c => new EcosystemMapItem
                    {
                        Id = c.Id,
                        Type = "Company",
                        Name = c.Name,
                        Description = c.Description,
                        Category = c.Sector,
                        Sector = c.Sector,
                        Ciudad = c.Ciudad,
                        Departamento = c.Department,
                        Latitud = c.Latitud,
                        Longitud = c.Longitud,
                        Contacto = c.Contacto,
                        Enlace = c.Url,
                        LogoUrl = c.LogoUrl,
                        CreatedAt = c.CreatedAt,
                        UpdatedAt = c.CreatedAt,
                        Metadata = new Dictionary<string, object?>
                        {
                            ["tipoActor"] = c.TipoActor,
                            ["direccion"] = c.Direccion
                        }
                    }));
                }

                // Incluir Articuladores si no se especifica filtro de tipo o si se incluye "Articulador"
                if (types == null || types.Contains("Articulador", StringComparer.OrdinalIgnoreCase))
                {
                    var articuladores = await _context.Articuladores
                        .Where(a =>
                            (departamento == null || a.Departamento == departamento) &&
                            (ciudad == null || a.Ciudad == ciudad) &&
                            a.Latitud != null && a.Longitud != null)
                        .ToListAsync();

                    items.AddRange(articuladores.Select(a => new EcosystemMapItem
                    {
                        Id = a.Id,
                        Type = "Articulador",
                        Name = a.Nombre,
                        Description = $"Articulador en {a.Region}",
                        Category = a.Tipo ?? "Articulador",
                        Ciudad = a.Ciudad,
                        Departamento = a.Departamento,
                        Latitud = a.Latitud,
                        Longitud = a.Longitud,
                        Contacto = a.Contacto,
                        CreatedAt = a.CreatedAt,
                        UpdatedAt = a.UpdatedAt,
                        Metadata = new Dictionary<string, object?>
                        {
                            ["tipo"] = a.Tipo,
                            ["region"] = a.Region
                        }
                    }));
                }

                _logger.LogInformation("Retrieved {Count} ecosystem items", items.Count);
                return items.OrderBy(i => i.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ecosystem map items");
                throw;
            }
        }
    }
}
