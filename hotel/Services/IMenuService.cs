using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetMenu();
        Task<Menu> GetMenu(int id);
        Task<Menu> CreateMenu(Menu menu);
        Task<bool> UpdateMenu(int id, Menu menu);
        Task<bool> DeleteMenu(int id);
    }
}
