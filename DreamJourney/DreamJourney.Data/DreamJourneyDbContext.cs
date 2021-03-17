using DreamJourney.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamJourney.Data
{
    public class DreamJourneyDbContext : DbContext
    {
        public DreamJourneyDbContext()
        {

        }

        public DreamJourneyDbContext(DbContextOptions<DreamJourneyDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripApplication> TripApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
