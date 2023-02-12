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
    public class TeacherService : ITeacherService
    {
        private readonly nurseryDbContext _context;
        public TeacherService(nurseryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetTeacher()
        {
            return await _context.Teacher.ToListAsync();
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            var group = await _context.Teacher.FindAsync(id);

            if (group == null)
            {
                return null;
            }

            return group;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            try
            {
                _context.Teacher.Add(teacher);
                await _context.SaveChangesAsync();

                return teacher;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.TeacherID)
            {
                return false;
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExist(id))
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

        public async Task<bool> DeleteTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return false;
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool TeacherExist(int id)
        {
            return _context.Teacher.Any(e => e.GroupId == id);
        }
    }
}
