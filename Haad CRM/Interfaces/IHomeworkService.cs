using Haad_CRM.Models.Homework;
using Haad_CRM.Models.Lesson;

namespace Haad_CRM.Interfaces;

public interface IHomeworkService
{
    Task<HomeworkViewModel> CreateAsync(HomeworkCreation lesson);

    Task<HomeworkViewModel> UpdateAsync(HomeworkUpdate lesson, long id);

    Task<bool> DeleteAsync(long id);

    Task<HomeworkViewModel> GetByIdAsync(long id);

    Task<List<HomeworkViewModel>> GetAllAsync();
}
