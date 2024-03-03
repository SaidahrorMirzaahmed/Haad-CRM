using Haad_CRM.Models.Attendances;

List<Attendance> attendanceList = new List<Attendance>
{
    new Attendance { StudentId = 1, GroupId = 101, AttendanceDate = DateTime.Now, Status = "Present" },
    new Attendance { StudentId = 2, GroupId = 102, AttendanceDate = DateTime.Now, Status = "Absent" },
    // Add more Attendance objects as needed
};
AttendanceReader attendanceReader = new AttendanceReader();
AttendanceWriter attendanceWriter = new AttendanceWriter();
attendanceWriter.UpdateAttendanceList(attendanceList);