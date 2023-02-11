using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        // GET: api/Child
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> Get()
        {
            var children = await _childService.GetChildren();
            return Ok(children);
        }

        // GET: api/Child/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Child>> Get(int id)
        {
            var child = await _childService.GetChild(id);

            if (child == null)
            {
                return NotFound();
            }

            return child;
        }

        // POST: api/Child
        [HttpPost]
        public async Task<ActionResult<Child>> Post(Child child)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdChild = await _childService.CreateChild(child);
            return CreatedAtAction(nameof(Get), new { id = createdChild.ChildID }, createdChild);
        }

        // PUT: api/Child/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Child child)
        {
            if (id != child.ChildID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _childService.UpdateChild(id, child);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Child/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _childService.DeleteChild(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
