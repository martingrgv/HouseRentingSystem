﻿using HouseRentingSystem.Core.Models.Enums;
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
    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int? agentId);
    Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);
    Task<bool> ExistsAsync(int id);
    Task<HouseDetailsViewModel?> HouseDetailsByIdAsync(int id);
 }
