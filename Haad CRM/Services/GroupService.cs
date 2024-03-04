using Haad_CRM.Helpers;
using Haad_CRM.Interfaces;
using Haad_CRM.Models.Course;
using Haad_CRM.Models.Group;
using System.Net.Http.Headers;

namespace Haad_CRM.Services;

public class GroupService : IGroupService
{
    private readonly List<Group> groups;
    public GroupService()
    {
        groups = new List<Group>();
    }

    public async Task<GroupViewModel> CreateAsync(GroupCreation group)
    {
        var creationGroup = groups.Create<Group>(group.MapTo<Group>());

        return creationGroup.MapTo<GroupViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultGroup = groups.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found group with this id");

        resultGroup.IsDeleted = true;

    }

    public Task<List<GroupViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GroupViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GroupViewModel> UpdateAsync(GroupCreation group, long id)
    {
        throw new NotImplementedException();
    }
}
