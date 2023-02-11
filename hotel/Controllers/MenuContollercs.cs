using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menus = await _menuService.GetMenus();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _menuService.GetMenuById(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            await _menuService.CreateMenu(menu);

            return CreatedAtAction(nameof(GetMenu), new { id = menu.MenuId }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            try
            {
                await _menuService.UpdateMenu(id, menu);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var result = await _menuService.DeleteMenu(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
