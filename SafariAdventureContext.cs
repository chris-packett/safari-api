using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using safari_api.Models;

namespace safari_api
{
    public partial class SafariAdventureContext : DbContext
    {
        public SafariAdventureContext()
        {
        }

        public SafariAdventureContext(DbContextOptions<SafariAdventureContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("server=localhost;database=SafariAdventure");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<Animal> Animals { get; set; }
    }
}
