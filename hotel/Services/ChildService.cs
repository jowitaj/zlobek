using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public class ChildService : IChildService
    {
        private readonly nurseryDbContext _context;

        public ChildService(nurseryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Child>> GetChildren()
        {
            return await _context.Child.ToListAsync();
        }

        public async Task<Child> GetChild(int id)
        {
            var child = await _context.Child.FindAsync(id);

            if (child == null)
            {
                return null;
            }

            return child;
        }

        public async Task<Child> CreateChild(Child child)
        {
            _context.Child.Add(child);
            await _context.SaveChangesAsync();

            return child;
        }

        public async Task<bool> UpdateChild(int id, Child child)
        {
            if (id != child.ChildID)
            {
                return false;
            }

            _context.Entry(child).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChildExists(id))
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

        public async Task<bool> DeleteChild(int id)
        {
            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return false;
            }

            _context.Child.Remove(child);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ChildExists(int id)
        {
            return _context.Child.Any(e => e.ChildID == id);
        }
    }
}
