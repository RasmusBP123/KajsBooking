using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] TestUser user)
        {
            var identityResult = await _accountRepository.CreateAccount(user.Email, user.Password);
            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }
            return BadRequest(identityResult.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] TestUser user)
        {
            var identityResult = await _accountRepository.Login(user.Email, user.Password);
            if (identityResult.Succeeded)
            {
                return Ok(identityResult);
            }
            return BadRequest();
        }



        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.Logout();
            return Ok();
        }
    }

    public class TestUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}