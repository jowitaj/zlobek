using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly nurseryDbContext _context;

        public ChildController(nurseryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> Get()
        {
            return await _context.Child.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> Get(int id)
        {
            var child = await _context.Child.FindAsync(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        [HttpPost]
        public async Task<ActionResult<Child>> Post(Child child)
        {
            _context.Child.Add(child);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = child.ChildID }, child);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Child child)
        {
            if (id != child.ChildID)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Child.Remove(child);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChildExists(int id)
        {
            return _context.Child.Any(e => e.ChildID == id);
        }
    }
}
