using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

public interface IGroupService
{
    Task<IEnumerable<Groups>> GetAllAsync();
    Task<Groups> GetByIdAsync(int id);
    Task<Groups> CreateAsync(Groups group);
    Task UpdateAsync(Groups group);
    Task DeleteAsync(int id);
}