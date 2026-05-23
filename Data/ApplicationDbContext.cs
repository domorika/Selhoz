using Microsoft.EntityFrameworkCore;
using Selhoz.Models;
using System.Collections.Generic;

namespace Selhoz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<PlantingJournal> PlantingJournals { get; set; }
    }
}