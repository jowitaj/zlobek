using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachers();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            var createdTeacher = await _teacherService.CreateTeacher(teacher);

            return CreatedAtAction(nameof(GetTeacher), new { id = createdTeacher.TeacherID }, createdTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.TeacherID)
            {
                return BadRequest();
            }

            
                await _teacherService.UpdateTeacher(id, teacher);
            
           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var deleted = await _teacherService.DeleteTeacher(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
