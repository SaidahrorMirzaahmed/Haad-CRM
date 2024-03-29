﻿namespace Haad_CRM.Models.Course;

using Haad_CRM.Models.Common;
using System;

public class Course:Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public int Price { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxEnrollment { get; set; }
}
