using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Enums;
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

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? search = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
    {
        return null;
        //var houses = repository.AllReadOnly<Infrastructure.Data.Models.House>();

        //if (category != null)
        //{
        //    houses = houses
        //        .Where(h => h.Category.Name == category);
        //}

        //if (search != null)
        //{
        //    string normalizedSearch = search.ToLower();
        //    houses = houses
        //        .Where(h => h.Title.ToLower().Contains(normalizedSearch) ||
        //            h.Address.ToLower().Contains(normalizedSearch) ||
        //            h.Description.ToLower().Contains(normalizedSearch));
        //}

        //houses = sorting switch
        //{
        //    HouseSorting.Price => houses.OrderByDescending( h => h.PricePerMonth),
        //    HouseSorting.NotRentedFirst => houses
        //        .OrderBy(h => h.RenterId == null)
        //        .ThenByDescending(h => h.RenterId),
        //    _ => houses.OrderByDescending(h => h.Id)
        //};


    }

    public Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        throw new NotImplementedException();
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
