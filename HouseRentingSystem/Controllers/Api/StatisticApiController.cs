using HouseRentingSystem.Core.Contracts.Api;
using HouseRentingSystem.Core.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistic")]
    public class StatisticApiController : Controller
    {
        private readonly IStatisticService statisticService;

        public StatisticApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;   
        }

        public async Task<StatisticServiceModel> GetStatistic()
        {
            return await statisticService.Total();
        }
    }
}
