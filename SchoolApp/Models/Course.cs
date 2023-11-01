using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int NbHour { get; set; }

    [Required]
    public int ModuleId { get; set; }
    public Module Module { get; set; }
}
