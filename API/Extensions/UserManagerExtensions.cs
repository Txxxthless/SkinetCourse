using System.Security.Claims;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAdress(
            this UserManager<AppUser> userManager,
            ClaimsPrincipal user
        )
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await userManager.Users
                .Include(user => user.Address)
                .SingleOrDefaultAsync(user => user.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(
            this UserManager<AppUser> userManager,
            ClaimsPrincipal inputUser
        )
        {
            return await userManager.Users.SingleOrDefaultAsync(
                user => user.Email == inputUser.FindFirstValue(ClaimTypes.Email)
            );
        }
    }
}
