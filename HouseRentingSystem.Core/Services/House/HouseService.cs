using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Enums;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.House;

public class HouseService : IHouseService
{
    private IRepository repository;

    public HouseService(IRepository _repository)
    {
        repository = _repository;
    }
   

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? search = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
    {
        var houses = repository.AllReadOnly<Infrastructure.Data.Models.House>();

        if (category != null)
        {
           houses = houses
               .Where(h => h.Category.Name == category);
        }

        if (search != null)
        {
           string normalizedSearch = search.ToLower();
           houses = houses
               .Where(h => h.Title.ToLower().Contains(normalizedSearch) ||
                   h.Address.ToLower().Contains(normalizedSearch) ||
                   h.Description.ToLower().Contains(normalizedSearch));
        }

        houses = sorting switch
        {
           HouseSorting.Price => houses.OrderBy( h => h.PricePerMonth),
           HouseSorting.NotRentedFirst => houses
               .OrderByDescending(h => h.RenterId == null)
               .ThenByDescending(h => h.RenterId),
           _ => houses.OrderByDescending(h => h.Id)
        };

        var housesToReturn = await houses
            .Skip((currentPage - 1) * housesPerPage)
            .Take(housesPerPage)
            .Select(h => new HouseServiceModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null
            })
            .ToListAsync();

            return new HouseQueryServiceModel
            {
                TotalHousesCount = houses.Count(),
                Houses = housesToReturn
            };
    }

    public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        return await repository.AllReadOnly<Category>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseCategoryServiceModel>> AllHouseCategoriesAsync()
    {
        return await repository.All<Category>()
            .Select(c => new HouseCategoryServiceModel
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int? agentId)
    {
        var houses = await repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .Where(h => h.AgentId == agentId)
            .ToListAsync();

        return ProjectToModel(houses);
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
    {
        var houses = await repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .Where(h => h.RenterId == userId)
            .ToListAsync();

        return ProjectToModel(houses);
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
    {
        return await repository.AllReadOnly<Category>()
            .AnyAsync(c => c.Id == categoryId);
    }

    public async Task<int> CreateAsync(HouseFormModel model, int agentId)
    {
        var house = new Infrastructure.Data.Models.House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = agentId,
        };

        await repository.AddAsync(house);
        await repository.SaveChangesAsync();

        return house.Id;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .AnyAsync(h => h.Id == id);
    }

    public async Task<HouseDetailsViewModel?> HouseDetailsByIdAsync(int id)
    {
        return await repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .Where(h => h.Id == id)
            .Select(h => new HouseDetailsViewModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null,
                Category = h.Category.Name,
                Agent = new Models.Agent.AgentServiceModel
                {
                    PhoneNumber = h.Agent.PhoneNumber
                }
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
    {
        return await repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseIndexServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .ToListAsync();
    }

    private List<HouseServiceModel> ProjectToModel(List<Infrastructure.Data.Models.House> houses)
    {
        var result = houses
            .Select(h => new HouseServiceModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null
            })
            .ToList();

        return result;
    }
}
