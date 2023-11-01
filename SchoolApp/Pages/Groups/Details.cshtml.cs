using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Pages.Groups;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public DetailsModel(AppDbContext db) => _db = db;




    public Group Group {  get; set; }
    public Module Module { get; set; }
    public List<string> daysOfWeek { get; set; }
    public List<string> Monday { get; set; }
    public List<string> Tuesday { get; set; }
    public List<string> Wednesday { get; set; }
    public List<string> Thursday { get; set; }
    public List<string> Friday { get; set; }
    public List<string> AllCourses { get; set; }




    public async Task OnGet(int id)
    {
        Group = await _db.Groups.FindAsync(id);
        Module = await _db.Modules.FindAsync(Group.ModuleId);

        daysOfWeek = new()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };


        var courses = await _db.Courses.Where(c => c.ModuleId == Module.Id).Select(c => c.Name).ToListAsync();
        var random = new Random();

        Monday = courses.OrderBy(_ => random.Next()).ToList();
        Tuesday = courses.OrderBy(_ => random.Next()).ToList();
        Wednesday = courses.OrderBy(_ => random.Next()).ToList();
        Thursday = courses.OrderBy(_ => random.Next()).ToList();
        Friday = courses.OrderBy(_ => random.Next()).ToList();

        AllCourses = new();

        AllCourses.AddRange(Monday.Take(4));
        AllCourses.AddRange(Tuesday.Take(4));
        AllCourses.AddRange(Wednesday.Take(4));
        AllCourses.AddRange(Thursday.Take(4));
        AllCourses.AddRange(Friday.Take(4));

        for (int i = 0; i < 8; i++)
            AllCourses.Add("");

    }



}
