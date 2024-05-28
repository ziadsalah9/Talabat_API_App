using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models.Identity;

namespace Talabat.Repository.Identity.DataSeed
{
    public static class AppIdentityDbContextSeed
    {

        public static async Task SeedAsync(UserManager<AppUser> userManager)
        {

            if(userManager.Users.Count() == 0)
            {
                var userdataseed = new AppUser()
                {
                    DisplayName = "ziadsalah",
                    Email = "ziads5933@gmail.com",
                    UserName = "ziadsalah",
                    PhoneNumber = "01020061562",
                    
                };

                await userManager.CreateAsync(userdataseed, "!ZSmafa01102212630");
            } 

        }
    }
}
