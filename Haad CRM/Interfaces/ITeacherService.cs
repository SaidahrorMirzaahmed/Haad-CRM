using Haad_CRM.Models.Student;
using Haad_CRM.Models.Teacher;

namespace Haad_CRM.Interfaces;

public interface ITeacherService
{
    Task<TeacherView> CreateAsync(TeacherCreation teacher);

    Task<bool> DeleteAsync(long id);

    Task<TeacherView> GetByIdAsync(long id);

    Task<TeacherView> UpdateAsync(TeacherUpdate teacher, long id);

    Task<List<TeacherView>> GetAllAsync();
}
