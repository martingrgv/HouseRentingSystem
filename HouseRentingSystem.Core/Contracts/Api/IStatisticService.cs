using HouseRentingSystem.Core.Models.Api;

namespace HouseRentingSystem.Core.Contracts.Api
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> Total();       
    }
}
