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

            await _db.Groups.AddAsync(group);
        }

        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
