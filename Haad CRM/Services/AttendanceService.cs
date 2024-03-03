using Haad_CRM.Helpers;
using Haad_CRM.Interfaces;
using Haad_CRM.Models.Attendance;

namespace Haad_CRM.Services;

public class AttendanceService : IAttendanceService
{
    private readonly List<Attendance> attendances;
    public AttendanceService()
    {
        attendances = new List<Attendance>();
    }

    public async Task<AttendanceViewModel> CreateAsync(AttendanceCreation attedance)
    {
        var creationAttendence = attendances.Create<Attendance>(attedance.MapTo<Attendance>());
        
        return creationAttendence.MapTo<AttendanceViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var resultAttendance = attendances.FirstOrDefault(attendance => attendance.Id == id)
            ?? throw new Exception("Not found attendance with this id");

        resultAttendance.IsDeleted = true;
        resultAttendance.DeletedAt = DateTime.UtcNow;

        return attendances.Remove(resultAttendance);
    }

    public async Task<List<AttendanceViewModel>> GetAllAsync()
    {
        return attendances.MapTo<AttendanceViewModel>();
    }

    public async Task<AttendanceViewModel> GetByIdAsync(long id)
    {
        var resultAttendance = attendances.FirstOrDefault(attendance => attendance.Id == id)
            ?? throw new Exception("Not found attendance with this id");

        return resultAttendance.MapTo<AttendanceViewModel>();
    }

    public async Task<AttendanceViewModel> UpdateAsync(AttendanceUpdate attendance, long id)
    {
        var resultAttendance = attendances.FirstOrDefault(attendance => attendance.Id == id)
            ?? throw new Exception("Not found attendance with this id");

        resultAttendance.Id = id;
        resultAttendance.UpdateAt = DateTime.UtcNow;
        resultAttendance.Status = attendance.Status;
        resultAttendance.GroupId = attendance.GroupId;
        resultAttendance.StudentId = attendance.StudentId;
        resultAttendance.AttendanceDate = attendance.AttendanceDate;

        return resultAttendance.MapTo<AttendanceViewModel>();
    }
}
