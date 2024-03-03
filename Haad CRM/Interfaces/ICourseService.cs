using Haad_CRM.Models.Course;

namespace Haad_CRM.Interfaces;

public interface ICourseService
{
    Task<CourseViewModel> CreateAsync(CourseCreation course);
   
    Task<CourseViewModel> UpdateAsync(CourseUpdate course,long id);
    
    Task<bool> DeleteAsync(long id);
    
    Task<CourseViewModel> GetByIdAsync(long id);
    
    Task<List<CourseViewModel>> GetAllAsync();
}
