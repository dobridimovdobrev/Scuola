using Microsoft.EntityFrameworkCore;

namespace Scuola.Models.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Studente> Studenti { get; set; }
    }
}
