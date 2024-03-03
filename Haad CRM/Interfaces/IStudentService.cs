using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface IStudentService
{
    Task<StudentViewModel> CreateAsync(StudentCreation student);

    Task<bool> DeleteAsync(long id);
<<<<<<< HEAD
<<<<<<< Updated upstream
    Task<StudentViewModel> GetByIdAsync(long id);
=======
    
    Task<Student> GetByIdAsync(long id);
    
>>>>>>> Stashed changes
=======
    
    Task<StudentViewModel> GetByIdAsync(long id);
    
>>>>>>> e7f51fd7b0221c0d9e1a28c16edc175ea713ae54
    Task<StudentViewModel> UpdateAsync(StudentUpdate student,long id);
    
    Task<List<StudentViewModel>> GetAllAsync();
}
