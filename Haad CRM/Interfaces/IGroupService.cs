using Haad_CRM.Models.Group;
using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface IGroupService
{
    Task<GroupViewModel> CreateAsync(GroupCreation group);

    Task<bool> DeleteAsync(long id);

    Task<GroupViewModel> GetByIdAsync(long id);

    Task<GroupViewModel> UpdateAsync(GroupCreation group, long id);

    Task<List<GroupViewModel>> GetAllAsync();
}
