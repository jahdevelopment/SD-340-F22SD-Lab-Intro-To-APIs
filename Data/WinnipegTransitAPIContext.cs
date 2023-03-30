using Microsoft.EntityFrameworkCore;
using SD_340_F22SD_Lab_Intro_To_APIs.Models;
using System.Reflection.Metadata;

namespace SD_340_F22SD_Lab_Intro_To_APIs.Data
{
    public class WinnipegTransitAPIContext : DbContext
    {
        public WinnipegTransitAPIContext()
        {

        }

        public WinnipegTransitAPIContext(DbContextOptions<WinnipegTransitAPIContext> options) : base(options)
        {

        }

        public virtual DbSet<Models.Route> Route { get; set; } = default!;

        public virtual DbSet<Models.ScheduledStop> ScheduledStop { get; set; } = default!;

        public virtual DbSet<Models.Stop> Stop { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Route>()
                        .HasKey(r => r.Number);

            modelBuilder.Entity<Models.Route>()
                        .Property(r => r.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Models.Route>()
                        .HasMany(r => r.ScheduledStops)
                        .WithOne(s => s.Route)
                        .HasForeignKey(s => s.RouteNumber);


            modelBuilder.Entity<Stop>()
                        .HasKey(s => s.Number);

            modelBuilder.Entity<Stop>()
                        .Property(s => s.Street)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Stop>()
                        .Property(s => s.Name)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Stop>()
                        .HasMany(s => s.ScheduledStops)
                        .WithOne(s => s.Stop)
                        .HasForeignKey(s => s.StopNumber);

        }
    }
}
