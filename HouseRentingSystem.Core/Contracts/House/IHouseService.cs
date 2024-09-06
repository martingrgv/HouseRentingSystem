using HouseRentingSystem.Core.Models.Enums;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts.House;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
    Task<IEnumerable<HouseCategoryServiceModel>> AllHouseCategoriesAsync();
    Task<bool> CategoryExistsAsync(int categoryId);
    Task<int> CreateAsync(HouseFormModel model, int agentId);
    Task<HouseQueryServiceModel> AllAsync(
       string? category = null,
       string? search = null,
       HouseSorting sorting = HouseSorting.Newest,
       int currentPage = 1,
       int housesPerPage = 1);
    Task<IEnumerable<string>> AllCategoriesNamesAsync();
    Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();
    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int? agentId);
    Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);
    Task<bool> ExistsAsync(int id);
    Task<HouseDetailsViewModel?> HouseDetailsByIdAsync(int id);
    Task<bool> HasAgentWithId(int houseId, string currentUserId);
    Task<int> GetHouseCategoryId(int houseId);
    Task Edit(int houseId, string title, string address, string description, string imageUrl, decimal price, int categoryId);
    Task DeleteAsync(int houseId);
    Task<bool> IsRented(int houseId);
    Task<bool> IsRentedWithUserWithId(int houseId, string userId);
    Task Rent(int houseId, string userId);
 }
