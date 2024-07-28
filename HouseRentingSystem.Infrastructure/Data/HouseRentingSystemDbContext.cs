using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;

public class HouseRentingSystemDbContext : DbContext
{
    public HouseRentingSystemDbContext() { }

    public HouseRentingSystemDbContext(DbContextOptions options) : base(options) { }

    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Agent> Agents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<House>()
            .HasOne(e => e.Category)
            .WithMany(e => e.Houses)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<House>()
            .HasOne(e => e.Agent)
            .WithMany()
            .HasForeignKey(e => e.AgentId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
