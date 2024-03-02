﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haad_CRM.Models.Student;

using System;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ParentPhoneNumber { get; set; }
    public string Email { get; set; }
    public int CoinId { get; set; }
    public int CourseId { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}
