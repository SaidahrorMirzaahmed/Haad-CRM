namespace Haad_CRM.Models.New;

using Haad_CRM.Models.Student;
using System;

public class NewsViewModel
{
    public long Id {  get; set; }
    public StudentViewModel Student { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
}
