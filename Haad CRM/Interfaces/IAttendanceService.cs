using Haad_CRM.Models.Attendance;
using Haad_CRM.Models.Student;

namespace Haad_CRM.Interfaces;

public interface IAttendanceService
{
    Task<AttendanceViewModel> CreateAsync(AttendanceCreation attedance);

    Task<bool> DeleteAsync(long id);

    Task<AttendanceViewModel> GetByIdAsync(long id);

    Task<AttendanceViewModel> UpdateAsync(AttendanceUpdate attendance, long id);

    Task<List<AttendanceViewModel>> GetAllAsync();
}
