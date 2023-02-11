using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using zlobek.Entities;

public class MenuService : IMenuService
{
    private readonly nurseryDbContext _context;

    public MenuService(nurseryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Menu>> GetMenus()
    {
        return await _context.Menu.ToListAsync();
    }

    public async Task<Menu> GetMenuById(int id)
    {
        return await _context.Menu.FindAsync(id);
    }

    public async Task<Menu> CreateMenu(Menu menu)
    {
        _context.Menu.Add(menu);
        await _context.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu> UpdateMenu(int id, Menu menu)
    {
        if (id != menu.MenuId)
        {
            throw new ArgumentException("Invalid menu id");
        }

        _context.Entry(menu).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return menu;
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
}