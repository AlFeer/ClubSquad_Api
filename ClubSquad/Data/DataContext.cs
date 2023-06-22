using ClubSquad.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubSquad.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
            .HasOne(_ => _.Team)
            .WithMany(a => a.Players)
            .HasForeignKey(p => p.TeamId);
        }
    }
}
