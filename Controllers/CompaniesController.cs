using Microsoft.AspNetCore.Mvc;
using BackInovationMap.Data;
using BackInovationMap.Models;

namespace BackInovationMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Companies.ToList());

        [HttpGet("health")]
        public IActionResult Health()
        {
            try
            {
                var count = _context.Companies.Count();
                return Ok(new
                {
                    status = "healthy",
                    message = "Backend is running correctly",
                    companiesCount = count,
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "unhealthy",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }
            return Ok(company);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company company)
        {
            var existingCompany = _context.Companies.Find(id);
            if (existingCompany == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            company.Id = id;
            existingCompany.Name = company.Name;
            existingCompany.Url = company.Url;
            existingCompany.LogoUrl = company.LogoUrl;
            existingCompany.Sector = company.Sector;
            existingCompany.Department = company.Department;
            existingCompany.Description = company.Description;

            _context.Companies.Update(existingCompany);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("debug")]
        [ProducesResponseType(200)]
        public IActionResult GetDebugInfo()
        {
            var companies = _context.Companies.ToList();
            return Ok(new
            {
                companies = companies,
                count = companies.Count,
                message = "Companies debug info"
            });
        }
    }
}
