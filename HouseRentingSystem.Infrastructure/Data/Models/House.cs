using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.ValidationConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House")]
    public class House
    {
        [Key]
        [Comment("House identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(HouseNameMaxLength)]
        [Comment("House title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(HouseAddressMaxLength)]
        [Comment("House address")]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(HouseDescriptionMaxLength)]
        [Comment("House description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("House image url")]
        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        [Comment("House monthy price")]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        [Comment("User renter identifier")]
        public string? RenterId { get; set; } = null!;
    }
}
