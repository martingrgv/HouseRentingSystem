using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            DataSeeder seeder = new DataSeeder();
            builder.HasData(new ApplicationUser[] { seeder.AgentUser, seeder.GuestUser });
        }
    }
}
