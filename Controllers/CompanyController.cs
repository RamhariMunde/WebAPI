using CreateWebAPI.Data;
using CreateWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public CompanyController(CompanyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCompany), new { companyCode = company.CompanyCode }, company);
        }

        [HttpGet]
        public IActionResult GetAllCompanies() => Ok(_context.Companies.ToList());

        [HttpGet("{companyCode}")]
        public IActionResult GetCompany(string companyCode)
        {
            var company = _context.Companies.Find(companyCode);
            return company == null ? NotFound() : Ok(company);
        }

        [HttpPut("{companyCode}")]
        public IActionResult UpdateCompany(string companyCode, [FromBody] Company company)
        {
            var existingCompany = _context.Companies.Find(companyCode);
            if (existingCompany == null) return NotFound();

            existingCompany.CompanyName = company.CompanyName;
            existingCompany.CompanyAddress = company.CompanyAddress;
            existingCompany.CompanyGSTN = company.CompanyGSTN;
            existingCompany.CompanyUserId = company.CompanyUserId;
            existingCompany.CompanyStatus = company.CompanyStatus;
            existingCompany.CompanyStartdate = company.CompanyStartdate;
            existingCompany.CompanyNatureofWork = company.CompanyNatureofWork;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{companyCode}")]
        public IActionResult DeleteCompany(string companyCode)
        {
            var company = _context.Companies.Find(companyCode);
            if (company == null) return NotFound();

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
