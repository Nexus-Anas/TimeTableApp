using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Course
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    public int NbHour { get; set; }
    public Module Module { get; set; }
}
