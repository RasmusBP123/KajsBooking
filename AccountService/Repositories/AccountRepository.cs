using AccountService.Interfaces;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApplicationDBContext _applicationDbContext;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IApplicationDBContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IdentityResult> CreateAccount(string email, string password)
        {
            var newUser = new ApplicationUser { Email = email, UserName = email };
            var account = await _userManager.CreateAsync(newUser, password);

            if (account.Succeeded)
            {
                if (newUser.Email.StartsWith("teacher"))
                {
                    await _userManager.AddToRoleAsync(newUser, Policies.IsTeacher);
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, Policies.IsStudent);
                }
            }
            _applicationDbContext.SaveChanges();

            return account;
        }

        public async Task<ApplicationUser> GetApplicationUser(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<SignInResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            return result;
        }

        public async Task Logout()
        {
           await _signInManager.SignOutAsync();
        }
    }
}
