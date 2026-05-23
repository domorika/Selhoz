using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Selhoz.Models;
using System.Text.RegularExpressions;

namespace Selhoz.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<PlantingJournal> PlantingJournal { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}