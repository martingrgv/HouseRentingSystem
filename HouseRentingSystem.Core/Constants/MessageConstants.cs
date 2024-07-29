namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} is required!";
        public const string LengthMessage = "The {0} must be between {2} and {1} characters!";
        public const string InvalidPhoneMessage = "The phone number must be valid!";
        public const string PhoneExistsMessage = "Phone number already exists. Enter another one.";
        public const string AgentHasRentMessage = "You should have not rents to become an agent!";
        public const string InvalidHousePriceMessage = "Price must be a positive number and less tha ${2}.";
        public const string CategoryNotExistingMessage = "Category doesn't exist!";
    }
}
