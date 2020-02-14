
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AccountService.Interfaces
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetApplicationUser(Guid id);
        Task<SignInResult> Login(string email, string password);
        Task<IdentityResult> CreateAccount(string email, string password);
        Task Logout();
    }
}
