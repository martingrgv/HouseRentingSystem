using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal PricePerMonth { get; set; }
        public bool IsRented { get; set; }
        public string Category { get; set; } = null!;
        public AgentServiceModel Agent { get; set; } = null!;
    }
}
