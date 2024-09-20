using HouseRentingSystem.Infrastructure.Data.Models;

namespace System.Security.Claims
{
    public static class ClaimsPrincipleExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminUser.AdminRoleName);
        }
    }
}
