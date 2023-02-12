using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public class MenuService : IMenuService
    {
        private readonly nurseryDbContext _context;
        public MenuService(nurseryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenu()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<Menu> GetMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);

            if (menu == null)
            {
                return null;
            }

            return menu;
        }

        public async Task<Menu> CreateMenu(Menu menu)
        {
            try
            {
                _context.Menu.Add(menu);
                await _context.SaveChangesAsync();

                return menu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateMenu(int id, Menu menu)
        {
            if (id != menu.MenuId)
            {
                return false;
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExist(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return false;
            }

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool MenuExist(int id)
        {
            return _context.Teacher.Any(e => e.GroupId == id);
        }
    }
}
