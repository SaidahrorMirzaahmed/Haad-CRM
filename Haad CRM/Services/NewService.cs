using Haad_CRM.Helpers;
using Haad_CRM.Models.Lesson;
using Haad_CRM.Models.New;

namespace Haad_CRM.Services;

public class NewService
{
    private readonly List<News> news;
    public NewService()
    {
        news = new List<News>();
    }

    public async Task<NewsViewModel> CreateAsync(NewsCreation newsCreation)
    {
        var existNew = news.FirstOrDefault(n => n.PublishDate == newsCreation.PublishDate && n.Title == newsCreation.Title);
        if (existNew != null && existNew.IsDeleted)
            return await UpdateAsync(existNew.MapTo<NewsUpdate>(), existNew.Id, true);
        if (existNew != null)
            throw new Exception("This news was created earlier");
        var creationNew = news.Create<News>(newsCreation.MapTo<News>());
        return creationNew.MapTo<NewsViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultNew = news.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found news with this id");

        resultNew.IsDeleted = true;
        resultNew.DeletedAd = DateTime.UtcNow;

        return true;
    }

    public async Task<List<NewsViewModel>> GetAllAsync()
    {
        return news.MapTo<NewsViewModel>();
    }

    public async Task<NewsViewModel> GetByIdAsync(long id)
    {
        var resultLesson = news.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found news with this id");

        return resultLesson.MapTo<LessonViewModel>();
    }

    public async Task<LessonViewModel> UpdateAsync(LessonUpdate lesson, long id, bool isDeleted = false)
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
