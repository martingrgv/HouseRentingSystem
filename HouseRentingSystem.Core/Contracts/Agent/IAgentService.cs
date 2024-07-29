namespace HouseRentingSystem.Core.Contracts.Agent
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
        Task<bool> UserHasRentAsync (string userId);
        Task CreateAsync(string userId, string phoneNumber);
    }
}
