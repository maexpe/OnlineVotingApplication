using Microsoft.AspNetCore.Identity;
using OnlineVotingApplication.Areas.Identity.Data;
using OnlineVotingApplication.Data;

namespace OnlineVotingApplication.Models
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(OnlineVotingApplicationContext context, IServiceProvider serviceProvider, UserManager<OnlineVotingApplicationUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            string[] roleTitles = { "Admin", "Voter", "Candidate" };
            
            IdentityResult roleResult;
            
            foreach (var RoleTitle in roleTitles)
            {
                var roleExists = await RoleManager.RoleExistsAsync(RoleTitle);

                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(RoleTitle));
                }
            }

            string Email = "admin@maexpe.com";
            string Password = "9K1CBTr3$*QK";

            if (userManager.FindByEmailAsync(Email).Result == null)
            {
                OnlineVotingApplicationUser user = new OnlineVotingApplicationUser();

                user.Username = Email;
                user.Email = Email;

                IdentityResult result = userManager.CreateAsync(user, Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
