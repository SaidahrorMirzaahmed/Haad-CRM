namespace Haad_CRM.Models.Student;

using Haad_CRM.Models.Course;
using System;

public class StudentViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ParentPhoneNumber { get; set; }
    public string Email { get; set; }
    public int CoinId { get; set; }
    public CourseViewModel Course { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
}