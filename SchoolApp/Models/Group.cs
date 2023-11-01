using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Group
{
    public int Id { get; set; }

    [Required]
    public int Num { get; set; }

    [Required]
    public int nbMaxStudents { get; set; }

    [Required]
    [MaxLength(30)]
    public string Level { get; set; }

    [Required]
    public int ModuleId { get; set; }
    public Module Module { get; set; }

    [Required]
    public int SalleId { get; set; }
    public Salle Salle { get; set; }
}
