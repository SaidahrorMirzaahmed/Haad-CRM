using Haad_CRM.Helpers;
using Haad_CRM.Interfaces;
<<<<<<< HEAD
using Haad_CRM.Models.Course;
using Haad_CRM.Models.Group;
using System.Net.Http.Headers;
=======
using Haad_CRM.Models.Group;

namespace Haad_CRM.Services;
>>>>>>> 34dda230dc2d48727371f54d7cdcb2b08bd9de38

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
<<<<<<< HEAD
        var creationGroup = groups.Create<Group>(group.MapTo<Group>());

=======
        var existGroup = groups.FirstOrDefault(g => g.Name == group.Name);
        if (existGroup != null && existGroup.IsDeleted)
            return await UpdateAsync(existGroup.MapTo<GroupUpdate>(), existGroup.Id, true);
        if (existGroup != null)
            throw new Exception("This group was created earlier");
        var creationGroup = groups.Create<Group>(group.MapTo<Group>());
>>>>>>> 34dda230dc2d48727371f54d7cdcb2b08bd9de38
        return creationGroup.MapTo<GroupViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultGroup = groups.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found group with this id");

        resultGroup.IsDeleted = true;
<<<<<<< HEAD

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
=======
        resultGroup.DeletedAd = DateTime.UtcNow;

        return true;
    }

    public async Task<List<GroupViewModel>> GetAllAsync()
    {
        return groups.MapTo<GroupViewModel>();
    }

    public async Task<GroupViewModel> GetByIdAsync(long id)
    {
        var resultGroup = groups.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found course with this id");

        return resultGroup.MapTo<GroupViewModel>();
    }

    public async Task<GroupViewModel> UpdateAsync(GroupUpdate group, long id,bool isDeleted = false)
    {
        var resultGroup = groups.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found course with this id");

        resultGroup.Id = id;
        resultGroup.Name = group.Name;
        resultGroup.EndDate = group.EndDate;
        resultGroup.CourseId = group.CourseId;
        resultGroup.UpdateAt = DateTime.UtcNow;
        resultGroup.StartDate = group.StartDate;
        resultGroup.TeacherID = group.TeacherID;
        resultGroup.ResourceId = group.ResourceId;
        resultGroup.DaysOfWeek = group.DaysOfWeek;

        return resultGroup.MapTo<GroupViewModel>();
>>>>>>> 34dda230dc2d48727371f54d7cdcb2b08bd9de38
    }
}

