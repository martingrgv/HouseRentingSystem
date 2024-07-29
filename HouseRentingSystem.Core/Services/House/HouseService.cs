using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.House;

public class HouseService : IHouseService
{
    private IRepository repository;

    public HouseService(IRepository _repository)
    {
        repository = _repository;
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
}
