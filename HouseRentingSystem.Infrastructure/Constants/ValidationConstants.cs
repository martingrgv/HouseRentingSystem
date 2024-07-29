namespace HouseRentingSystem.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public const int CategoryNameMaxLength = 20;

        public const int HouseNameMaxLength = 50;
        public const int HouseAddressMaxLength = 150;
        public const int HouseDescriptionMaxLength = 500;
        public const string HousePricePerMonthMinRange = "0.00";
        public const string HousePricePerMonthMaxRange = "2000.00";

        public const int AgentPhoneNumberMinLength = 7;
        public const int AgentPhoneNumberMaxLength = 15;
    }
}
