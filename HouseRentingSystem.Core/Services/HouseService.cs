using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models;

namespace HouseRentingSystem.Core.Services;

public class HouseService : IHouseService
{
    public Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
    {
        throw new NotImplementedException();
    }
}
