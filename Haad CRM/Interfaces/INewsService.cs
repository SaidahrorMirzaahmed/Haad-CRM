using Haad_CRM.Models.New;
using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface INewsService
{
    Task<NewsViewModel> CreateAsync(NewsCreation news);

    Task<bool> DeleteAsync(long id);

    Task<NewsViewModel> GetByIdAsync(long id);

    Task<NewsViewModel> UpdateAsync(NewsUpdate news, long id);

    Task<List<NewsViewModel>> GetAllAsync();
}
