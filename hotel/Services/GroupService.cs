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
    public class GroupService : IGroupService
    {
        private readonly nurseryDbContext _context;
        public GroupService(nurseryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Groups>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Groups> GetGroups(int id)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return null;
            }

            return group;
        }

        public async Task<Groups> CreateGroups(Groups group)
        {
            try
            {
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();
               
                return group;
            }
            catch (Exception)
            {
   
                throw;
            }
        }

        public async Task<bool> UpdateGroups(int id, Groups group)
        {
            if (id != group.GroupId)
            {
                return false;
            }

            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        public async Task<bool> DeleteGroups(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return false;
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool GroupsExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
