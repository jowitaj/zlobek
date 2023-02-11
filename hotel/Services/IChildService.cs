using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> GetChildren();
        Task<Child> GetChild(int id);
        Task<Child> CreateChild(Child child);
        Task<bool> UpdateChild(int id, Child child);
        Task<bool> DeleteChild(int id);
    }
}
