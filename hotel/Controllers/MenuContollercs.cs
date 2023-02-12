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
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;


        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;

        }
        [Authorize(Roles = "admin,teacher,parent")]
        [HttpGet]
        public async Task<IActionResult> MenuList()
        {
            var menu = await _menuService.GetMenu();
            return View(menu);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                await _menuService.CreateMenu(menu);

                return View(menu);
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
        public async Task<IActionResult> Edit(Menu menu)
        {

            menu.MenuId = int.Parse(Request.Form["menuId"]);

            var result = await _menuService.UpdateMenu(menu.MenuId, menu);



            return View(menu);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Menu menu)
        {

            menu.MenuId = int.Parse(Request.Form["menuId"]);
            var result = await _menuService.DeleteMenu(menu.MenuId);

            return View();
        }
    }
}
