namespace SchoolApp.Models;

public class Salle
{
    public int Id { get; set; }
    public int nbMaxPlaces { get; set; }
    public List<Group> Groups { get; set; }
}