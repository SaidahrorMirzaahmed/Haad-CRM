using Haad_CRM.Helpers;
using Haad_CRM.Interfaces;
using Haad_CRM.Models.Ball;
using Haad_CRM.Models.Course;

namespace Haad_CRM.Services;

public class CourseService : ICourseService
{
    private readonly List<Course> courses;
    public CourseService()
    {
        courses = new List<Course>();
    }

    public  async Task<CourseViewModel> CreateAsync(CourseCreation course)
    {
        var creationcourse = courses.Create<Course>(course.MapTo<Course>());

        return creationcourse.MapTo<CourseViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultCourse = courses.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found course with this id");

        resultCourse.IsDeleted = true;
        resultCourse.DeletedAt = DateTime.UtcNow;

        return courses.Remove(resultCourse);
    }

    public async Task<List<CourseViewModel>> GetAllAsync()
    {
        return courses.MapTo<CourseViewModel>();
    }

    public async Task<CourseViewModel> GetByIdAsync(long id)
    {
        var resultCourse = courses.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found course with this id");

        return resultCourse.MapTo<CourseViewModel>();
    }

    public async Task<CourseViewModel> UpdateAsync(CourseUpdate course, long id)
    {
        var resultCourse = courses.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Not found course with this id");

        resultCourse.Id = id;
        resultCourse.Name = course.Name;
        resultCourse.Price = course.Price;
        resultCourse.EndDate = course.EndDate;
        resultCourse.Duration = course.Duration;
        resultCourse.UpdateAt = DateTime.UtcNow;
        resultCourse.StartDate = course.StartDate;
        resultCourse.Description = course.Description;
        resultCourse.MaxEnrollment = course.MaxEnrollment;
        
        return resultCourse.MapTo<CourseViewModel>();
    }
}
