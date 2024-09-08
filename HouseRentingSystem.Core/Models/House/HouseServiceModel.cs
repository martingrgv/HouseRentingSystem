using System.ComponentModel;
using HouseRentingSystem.Infrastructure.Contracts;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [DisplayName("Monthy price")]
        public decimal PricePerMonth { get; set; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; set; }
    }
}