namespace Haad_CRM.Models.Attendances;

using Haad_CRM.Models.Common;
using System;

public class Attendance : Auditable
{
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string Status { get; set; }
}
