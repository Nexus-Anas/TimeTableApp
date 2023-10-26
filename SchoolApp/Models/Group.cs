using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models;

public class Group
{
    public int Id { get; set; }
    public int Num { get; set; }
    public int nbMaxStudents { get; set; }
    [MaxLength(30)]
    public string Level { get; set; }
    public Module Module { get; set; }
    public List<Salle> Salles { get; set; }
}
