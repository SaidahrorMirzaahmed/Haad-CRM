namespace Haad_CRM.Models.Attendance;

using System;

public class AttendanceViewModel
{
    public long Id {  get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string Status { get; set; }
}
