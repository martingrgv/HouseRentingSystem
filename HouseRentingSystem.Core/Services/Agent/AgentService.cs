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

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            var entity = new Infrastructure.Data.Models.Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentByIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }

        public async Task<bool> UserHasRentAsync(string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.House>()
                .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
