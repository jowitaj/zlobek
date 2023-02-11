using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using zlobek.Entities;

public class TeacherService : ITeacherService
{
    private readonly nurseryDbContext _context;

    public TeacherService(nurseryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetTeachers()
    {
        return await _context.Teacher.ToListAsync();
    }

    public async Task<Teacher> GetTeacherById(int id)
    {
        return await _context.Teacher.FindAsync(id);
    }

    public async Task<Teacher> CreateTeacher(Teacher teacher)
    {
        _context.Teacher.Add(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
    {
        if (id != teacher.TeacherID)
        {
            throw new ArgumentException("Invalid teacher id");
        }

        _context.Entry(teacher).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return teacher;
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
}