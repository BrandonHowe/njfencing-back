using Microsoft.EntityFrameworkCore;
using NJFencing.Models;
using NJFencing.Utilities;

namespace NJFencing.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<DualMeet> DualMeets { get; set; }
    public DbSet<Fencer> Fencers { get; set; }
    public DbSet<FencerRecord> FencerRecords { get; set; }
    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<FencerRecord>()
            .Property(e => e.Weapon)
            .HasConversion(
                v => v.ToString(),
                v => (Weapon)Enum.Parse(typeof(Weapon), v));

        modelBuilder
            .Entity<Team>()
            .Property(e => e.Conference)
            .HasConversion(
                v => v.ToString(),
                v => (Conference)Enum.Parse(typeof(Conference), v));
        
        modelBuilder
            .Entity<Team>()
            .Property(e => e.Gender)
            .HasConversion(
                v => v == Gender.Mens ? "Men's" : "Women's",
                v => v == "Women's" ? Gender.Womens : Gender.Mens);
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
}