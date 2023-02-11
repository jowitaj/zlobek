using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{

    public class GroupService : IGroupService
    {
        private readonly nurseryDbContext _context;

        public GroupService(nurseryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Groups>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Groups> GetByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<Groups> CreateAsync(Groups group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task UpdateAsync(Groups group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
