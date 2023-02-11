using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zlobek.Entities;
using zlobek.Services;

namespace zlobek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groups>>> GetGroups()
        {
            return Ok(await _groupService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Groups>> GetGroup(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<Groups>> PostGroup(Groups group)
        {
            if (!IsValidGroupName(group.Name))
            {
                return BadRequest("Invalid group name. Only alphanumeric characters and spaces are allowed.");
            }

            var createdGroup = await _groupService.CreateAsync(group);

            return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.GroupId }, createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Groups group)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }

            if (!IsValidGroupName(group.Name))
            {
                return BadRequest("Invalid group name. Only alphanumeric characters and spaces are allowed.");
            }

            await _groupService.UpdateAsync(group);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            await _groupService.DeleteAsync(id);

            return NoContent();
        }

        private bool IsValidGroupName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z0-9\s]+$");
        }
    }
}
