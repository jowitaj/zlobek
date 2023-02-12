using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model.Email, model.Password);

                
                    return RedirectToAction("Index", "Home");
               
            }

            return View(model);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> AccountList()
        {
            var account = await _accountService.GetAccount();
            return View(account);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {

            account.AccountId = int.Parse(Request.Form["AccountId"]);

            var result = await _accountService.UpdateAccount(account.AccountId, account);



            return View(account);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Account account)
        {

            account.AccountId = int.Parse(Request.Form["AccountId"]);
            var result = await _accountService.DeleteAccount(account.AccountId);

            return View();
        }
    }
}
