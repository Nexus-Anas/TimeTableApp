using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Module
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
    public List<Group> Groups { get; set; }
}
