﻿using HouseRentingSystem.Infrastructure.Data.Configurations;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;

public class HouseRentingSystemDbContext : IdentityDbContext<ApplicationUser>
{
    public HouseRentingSystemDbContext() { }

    public HouseRentingSystemDbContext(DbContextOptions options) : base(options) { }

    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Agent> Agents { get; set; } = null!;
    
    private ApplicationUser AgentUser { get; set; } = null!;
    private ApplicationUser GuestUser { get; set; } = null!;
    private ApplicationUser AdminUser { get; set; } = null!;
    private Agent AdminAgent { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HouseConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new AgentConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
