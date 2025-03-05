
using CreateWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreateWebAPI.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
