namespace Haad_CRM.Models.Teacher;

using Haad_CRM.Models.Common;
using System;

public class Teacher:Auditable
{

    public long ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
