using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Pages.Groups;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;




    [BindProperty]
    [Required]
    public int NumberOfStudents { get; set; }

    [BindProperty]
    [Required]
    public string Level { get; set; }

    [BindProperty]
    public int ModuleID { get; set; }
    public List<Module> Modules { get; set; }
    public List<Salle> Salles { get; set; }
    public List<Group> Groups { get; set; }


    public List<int> Monday { get; set; }
    public List<int> Tuesday { get; set; }
    public List<int> Wednesday { get; set; }
    public List<int> Thursday { get; set; }
    public List<int> Friday { get; set; }
    public List<int> AllCourses { get; set; }



    public async Task OnGet()
    {
        Groups = await _db.Groups.ToListAsync();
        Salles = await _db.Salles.ToListAsync();
        Modules = await _db.Modules.ToListAsync();
    }




    public async Task<IActionResult> OnPostCreate()
    {
        int numberOfGroups = (int)Math.Ceiling((double)NumberOfStudents / 20);

        int studentsPerGroup = NumberOfStudents / numberOfGroups;
        int remainingStudents = NumberOfStudents % numberOfGroups;

        var sallesNotInGroups = await _db.Salles.Where(s => !_db.Groups.Any(g => g.SalleId == s.Id)).ToListAsync();

        var groupCount = await _db.Groups.CountAsync();

        var courses = await _db.Courses.Where(c => c.ModuleId == ModuleID).Select(c => c.Id).ToListAsync();

        for (int i = 0; i < numberOfGroups; i++)
        {
            var group = new Group
            {
                Num = groupCount + (i+1),
                nbMaxStudents = studentsPerGroup + (i < remainingStudents ? 1 : 0),
                Level = Level,
                ModuleId = ModuleID,
                SalleId = sallesNotInGroups[i].Id
            };


            Random random = new();

            Monday = courses.OrderBy(_ => random.Next()).ToList();
            Tuesday = courses.OrderBy(_ => random.Next()).ToList();
            Wednesday = courses.OrderBy(_ => random.Next()).ToList();
            Thursday = courses.OrderBy(_ => random.Next()).ToList();
            Friday = courses.OrderBy(_ => random.Next()).ToList();

            var timetable = new TimeTable
            {
                GroupNum = group.Num,
                CourseId1 = Monday[0],
                CourseId2 = Monday[1],
                CourseId3 = Monday[2],
                CourseId4 = Monday[3],
                CourseId5 = Tuesday[0],
                CourseId6 = Tuesday[1],
                CourseId7 = Tuesday[2],
                CourseId8 = Tuesday[3],
                CourseId9 = Wednesday[0],
                CourseId10 = Wednesday[1],
                CourseId11 = Wednesday[2],
                CourseId12 = Wednesday[3],
                CourseId13 = Thursday[0],
                CourseId14 = Thursday[1],
                CourseId15 = Thursday[2],
                CourseId16 = Thursday[3],
                CourseId17 = Friday[0],
                CourseId18 = Friday[1],
                CourseId19 = Friday[2],
                CourseId20 = Friday[3]
            };

            await _db.Groups.AddAsync(group);
            await _db.TimeTables.AddAsync(timetable);
        }

        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
