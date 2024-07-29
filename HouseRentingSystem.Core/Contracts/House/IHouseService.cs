using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts.House;

public interface IHouseService
{
    public Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
}
