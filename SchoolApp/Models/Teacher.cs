using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Teacher
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; }
}