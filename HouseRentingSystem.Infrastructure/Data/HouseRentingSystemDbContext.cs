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
}
