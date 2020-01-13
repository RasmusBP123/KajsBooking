using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDBContextSeed
    {

       public static async Task CreateUser(UserManager<ApplicationUser> manager)
        {
            var defaultUser = new ApplicationUser() { UserName = "Admin", Email = "admin@hotmail.com" };
            if (manager.Users.All(user => user.Id != defaultUser.Id))
            {
                await manager.CreateAsync(defaultUser, "Horse123!");
            }
       } 
    }
}
