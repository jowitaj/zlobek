using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> MenuList()
        {
            var menu = await _menuService.GetMenu();
            return View(menu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Menu menu)
        {

            menu.MenuId = int.Parse(Request.Form["menuId"]);

            var result = await _menuService.UpdateMenu(menu.MenuId, menu);



            return View(menu);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Menu menu)
        {

            menu.MenuId = int.Parse(Request.Form["menuId"]);
            var result = await _menuService.DeleteMenu(menu.MenuId);

            return View();
        }
    }
}
