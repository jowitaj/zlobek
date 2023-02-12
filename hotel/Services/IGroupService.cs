using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Groups>> GetGroups();
        Task<Groups> GetGroups(int id);
        Task<Groups> CreateGroups(Groups group);
        Task<bool> UpdateGroups(int id, Groups group);
        Task<bool> DeleteGroups(int id);
    }
}
