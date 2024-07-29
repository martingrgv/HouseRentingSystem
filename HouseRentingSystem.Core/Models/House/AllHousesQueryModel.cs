using System.ComponentModel;
using HouseRentingSystem.Core.Models.Enums;

namespace HouseRentingSystem.Core.Models.House
{
    public class AllHousesQueryModel
    {
        public const int HousesPerPage  = 3;

        public string Category { get; set; } = null!;
        
        [DisplayName("Search by text")]
        public string SearchItem { get; set; } = null!;

        public HouseSorting HouseSorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public IEnumerable<string> Categories { get; set; } = null!;

        public int TotalHousesCount { get; set; } = 0;

        public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
    }
}
