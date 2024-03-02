namespace Haad_CRM.Models.Student;

using System;

public class StudentUpdate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ParentPhoneNumber { get; set; }
    public string Email { get; set; }
    public int CoinId { get; set; }
    public int CourseId { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}