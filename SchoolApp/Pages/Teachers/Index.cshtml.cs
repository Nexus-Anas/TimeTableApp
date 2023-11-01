using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Teachers;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Teacher Teacher { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Course> Courses { get; set; }




    public async Task OnGet()
    {
        Teachers = await _db.Teachers.ToListAsync();
        Courses = await _db.Courses.ToListAsync();
    }




    public async Task<IActionResult> OnPostCreate()
    {
        await _db.Teachers.AddAsync(Teacher);
        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
