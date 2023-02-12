using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetTeacher();
        Task<Teacher> GetTeacher(int id);
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<bool> UpdateTeacher(int id, Teacher teacher);
        Task<bool> DeleteTeacher(int id);
    }
}
