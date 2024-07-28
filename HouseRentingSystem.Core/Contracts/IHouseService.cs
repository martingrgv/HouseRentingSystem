using HouseRentingSystem.Core.Models;

namespace HouseRentingSystem.Core.Contracts;

public interface IHouseService
{
    public Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
}
