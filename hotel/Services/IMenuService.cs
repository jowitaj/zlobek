using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

public interface IMenuService
{
    Task<List<Menu>> GetMenus();
    Task<Menu> GetMenuById(int id);
    Task<Menu> CreateMenu(Menu menu);
    Task<Menu> UpdateMenu(int id, Menu menu);
    Task<bool> DeleteMenu(int id);
}