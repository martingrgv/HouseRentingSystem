using HouseRentingSystem.Core.Contracts.Api;
using HouseRentingSystem.Core.Models.Api;
using HouseRentingSystem.Infrastructure.Common;

namespace HouseRentingSystem.Core.Services.Api
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public Task<StatisticServiceModel> Total()
        {
            int housesCount = repository
                .AllReadOnly<Infrastructure.Data.Models.House>()
                .Count();

            int rentsCount = repository
                .AllReadOnly<Infrastructure.Data.Models.House>()
                .Where(h => h.RenterId != null)
                .Count();

            var serviceModel = new StatisticServiceModel
            {
                TotalHouses = housesCount,
                TotalRents = rentsCount
            };

            return Task.FromResult(serviceModel);
        }
    }
}
