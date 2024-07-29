namespace HouseRentingSystem.Core.Contracts.Agent
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);
    }
}
