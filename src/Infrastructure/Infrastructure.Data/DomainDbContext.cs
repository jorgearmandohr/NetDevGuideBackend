using Domain.Model.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
    }
}