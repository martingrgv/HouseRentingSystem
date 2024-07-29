using HouseRentingSystem.Core.Contracts.Agent;
using HouseRentingSystem.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .AnyAsync(a => a.UserId == userId);
        }
    }
}
