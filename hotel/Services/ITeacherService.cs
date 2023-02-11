using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

public interface ITeacherService
{
    Task<List<Teacher>> GetTeachers();
    Task<Teacher> GetTeacherById(int id);
    Task<Teacher> CreateTeacher(Teacher teacher);
    Task<Teacher> UpdateTeacher(int id, Teacher teacher);
    Task<bool> DeleteTeacher(int id);
}