namespace HouseRentingSystem.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        // House
        public const int CategoryNameMaxLength = 20;
        public const int HouseNameMinLength = 10;
        public const int HouseNameMaxLength = 50;
        public const int HouseAddressMinLength = 20;
        public const int HouseAddressMaxLength = 150;
        public const int HouseDescriptionMinLength = 30;
        public const int HouseDescriptionMaxLength = 500;
        public const double HousePricePerMonthMinRange = 0.00;
        public const double HousePricePerMonthMaxRange = 2000.00;

        // Agent
        public const int AgentPhoneNumberMinLength = 7;
        public const int AgentPhoneNumberMaxLength = 15;

        // User
        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 12;
        public const int UserLasttNameMinLength = 2;
        public const int UserLastNameMaxLength = 20;
    }
}
