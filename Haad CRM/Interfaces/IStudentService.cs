using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface IStudentService
{
    Task<StudentViewModel> CreateAsync(StudentCreation student);

    Task<bool> DeleteAsync(long id);
    
    Task<StudentViewModel> GetByIdAsync(long id);
    
    Task<StudentViewModel> UpdateAsync(StudentUpdate student,long id);
    
    Task<List<StudentViewModel>> GetAllAsync();
}
