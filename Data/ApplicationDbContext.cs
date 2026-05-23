using Microsoft.EntityFrameworkCore;
using Selhoz.Models;

namespace Selhoz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<PlantingJournal> PlantingJournals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}