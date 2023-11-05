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
    public TimeTable TimeTable { get; set; }
    public List<string> daysOfWeek { get; set; }
    public List<string> Courses { get; set; }




    public async Task OnGet(int id)
    {
        Group = await _db.Groups.FindAsync(id);
        Module = await _db.Modules.FindAsync(Group.ModuleId);
        TimeTable = await _db.TimeTables.Where(t => t.GroupNum == Group.Num).FirstOrDefaultAsync();

        daysOfWeek = new()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };
        Courses = new();
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId1).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId2).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId3).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId4).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId5).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId6).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId7).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId8).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId9).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId10).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId11).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId12).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId13).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId14).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId15).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId16).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId17).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId18).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId19).Select(c => c.Name).FirstOrDefaultAsync());
        Courses.Add(await _db.Courses.Where(c => c.Id == TimeTable.CourseId20).Select(c => c.Name).FirstOrDefaultAsync());
    }
}
