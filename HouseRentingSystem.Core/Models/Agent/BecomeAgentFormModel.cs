using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.ValidationConstants;

namespace HouseRentingSystem.Core.Models.Agent
{
    public class BecomeAgentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AgentPhoneNumberMaxLength, MinimumLength = AgentPhoneNumberMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone(ErrorMessage = PhoneErrorMessage)]
        public string PhoneNumber { get; set; } = null!;
    }
}
