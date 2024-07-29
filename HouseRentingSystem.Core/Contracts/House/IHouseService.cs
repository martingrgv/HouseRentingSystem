using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts.House;

public interface IHouseService
{
    public Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
    public Task<IEnumerable<HouseCategoryServiceModel>> AllHouseCategoriesAsync();
    public Task<bool> CategoryExistsAsync(int categoryId);
    public Task<int> CreateAsync(HouseFormModel model, int agentId);
}
