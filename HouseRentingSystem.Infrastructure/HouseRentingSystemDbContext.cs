using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure;

public class HouseRentingSystemDbContext : DbContext
{
    public HouseRentingSystemDbContext() {}

    public HouseRentingSystemDbContext(DbContextOptions options) : base(options) {}
}
