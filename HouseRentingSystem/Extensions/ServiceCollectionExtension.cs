<<<<<<< HEAD
﻿using HouseRentingSystem.Infrastructure.Data;
=======
﻿using HouseRentingSystem.Core.Contracts.Agent;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Services.Agent;
using HouseRentingSystem.Core.Services.House;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data;
>>>>>>> 2c82bff436796642161bc3d0048e9bd00c5ac8e0
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services)
    {
<<<<<<< HEAD
=======
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IAgentService, AgentService>();

>>>>>>> 2c82bff436796642161bc3d0048e9bd00c5ac8e0
        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<HouseRentingSystemDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IRepository, Repository>();

        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
        })
        .AddEntityFrameworkStores<HouseRentingSystemDbContext>();

        return services;
    }
}
