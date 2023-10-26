using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Teacher
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public Course Course { get; set; }
}