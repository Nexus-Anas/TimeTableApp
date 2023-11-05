using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class TimeTable
{
    public int Id { get; set; }

    [Required]
    public int GroupNum { get; set; }

    public int CourseId1 { get; set; }
    public int CourseId2 { get; set; }
    public int CourseId3 { get; set; }
    public int CourseId4 { get; set; }
    public int CourseId5 { get; set; }
    public int CourseId6 { get; set; }
    public int CourseId7 { get; set; }
    public int CourseId8 { get; set; }
    public int CourseId9 { get; set; }
    public int CourseId10 { get; set; }
    public int CourseId11 { get; set; }
    public int CourseId12 { get; set; }
    public int CourseId13 { get; set; }
    public int CourseId14 { get; set; }
    public int CourseId15 { get; set; }
    public int CourseId16 { get; set; }
    public int CourseId17 { get; set; }
    public int CourseId18 { get; set; }
    public int CourseId19 { get; set; }
    public int CourseId20 { get; set; }
}
