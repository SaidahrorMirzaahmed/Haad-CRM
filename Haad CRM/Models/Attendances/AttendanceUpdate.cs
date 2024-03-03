namespace Haad_CRM.Models.Attendance;

using System;

public class AttendanceUpdate
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string Status { get; set; }
}
