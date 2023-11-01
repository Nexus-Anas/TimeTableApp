using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Courses;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Course Course { get; set; }
    public List<Course> Courses { get; set; }
    public List<Module> Modules { get; set; }




    public async Task OnGet()
    {
        Courses = await _db.Courses.ToListAsync();
        Modules = await _db.Modules.ToListAsync();
    }




    public async Task<IActionResult> OnPostCreate()
    {
        await _db.Courses.AddAsync(Course);
        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
