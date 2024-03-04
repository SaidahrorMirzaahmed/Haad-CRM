using Haad_CRM.Helpers;
using Haad_CRM.Models.Lesson;

namespace Haad_CRM.Services;

public class LessonService
{
    private readonly List<Lesson> lessons;
    public LessonService()
    {
        lessons = new List<Lesson>();
    }

    public async Task<LessonViewModel> CreateAsync(LessonCreation lesson)
    {
        var existLesson = lessons.FirstOrDefault(l => l.Name == lesson.Name && l.GroupId == lesson.GroupId);
        if (existLesson != null && existLesson.IsDeleted)
            return await UpdateAsync(existLesson.MapTo<LessonUpdate>(), existLesson.Id, true);
        if (existLesson != null)
            throw new Exception("This lesson was created earlier");
        var creationLesson = lessons.Create<Lesson>(lesson.MapTo<Lesson>());
        return creationLesson.MapTo<LessonViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultLesson = lessons.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found lesson with this id");

        resultLesson.IsDeleted = true;
        resultLesson.DeletedAd = DateTime.UtcNow;

        return true;
    }

    public async Task<List<LessonViewModel>> GetAllAsync()
    {
        return lessons.MapTo<LessonViewModel>();
    }

    public async Task<LessonViewModel> GetByIdAsync(long id)
    {
        var resultLesson = lessons.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found lesson with this id");

        return resultLesson.MapTo<LessonViewModel>();
    }

    public async Task<LessonViewModel> UpdateAsync(LessonUpdate lesson ,long id, bool isDeleted = false)
    {
        var resultLesson = lessons.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found lesson with this id");

        resultLesson.Id = id;
        resultLesson.Name = lesson.Name;
        resultLesson.GroupId = lesson.GroupId;
        resultLesson.LToDate = lesson.LToDate;
        resultLesson.UpdateAt = DateTime.UtcNow;
        resultLesson.LFromDate = lesson.LFromDate;

        return resultLesson.MapTo<LessonViewModel>();
    }
}
