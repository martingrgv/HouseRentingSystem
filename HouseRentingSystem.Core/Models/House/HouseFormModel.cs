using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Infrastructure.Data.Models;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.ValidationConstants;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseFormModel
    {
        [Required]
        [StringLength(HouseNameMaxLength, MinimumLength = HouseNameMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(HousePricePerMonthMinRange, HousePricePerMonthMaxRange, ErrorMessage = InvalidHousePriceMessage)]
        [Display(Name = "Monthy price")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "House category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
    }
}
