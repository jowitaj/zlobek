using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using zlobek.Entities;
using zlobek.Services;
using Microsoft.AspNetCore.Http;

namespace zlobek.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher<Account> _passwordHasher;

        public AccountController(IAccountService accountService, IPasswordHasher<Account> passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;

        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Account model)
        {
            if (ModelState.IsValid)
            {
                var account = await _accountService.GetAccountByEmail(model.Email);
                var role = await _accountService.GetRoleForAccount(model.Email);

                if (account != null)
                {
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(account, account.Password, model.Password);
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Email),
                new Claim(ClaimTypes.Role, account.Role.Name)
            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                      
                        Response.Cookies.Append("AuthCookie", "authenticated");
                        
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View("~/Views/Home/menu.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> AccountList()
        {
            var account = await _accountService.GetAccount();
            return View(account);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.CreateAccount(account);

                return View(account);
            }
            return BadRequest();



        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {

            account.AccountId = int.Parse(Request.Form["AccountId"]);

            var result = await _accountService.UpdateAccount(account.AccountId, account);



            return View(account);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Account account)
        {

            account.AccountId = int.Parse(Request.Form["AccountId"]);
            var result = await _accountService.DeleteAccount(account.AccountId);

            return View();
        }
    }
}
