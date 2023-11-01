using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Teachers;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public DetailsModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Teacher Teacher { get; set; }
    public List<Course> Courses { get; set; }




    public async Task OnGet(int id)
    {
        Teacher = await _db.Teachers.FindAsync(id);
        Courses = await _db.Courses.ToListAsync();
    }




    public async Task<IActionResult> OnPostUpdate()
    {
        var teacher = await _db.Teachers.FindAsync(Teacher.Id);
        teacher.Name = Teacher.Name;
        teacher.CourseId = Teacher.CourseId;
        await _db.SaveChangesAsync();
        return RedirectToPage("/Teachers/Index");
    }




    public async Task<IActionResult> OnPostDelete()
    {
        var teacher = await _db.Teachers.FindAsync(Teacher.Id);

        if (teacher is null)
            return NotFound();

        _db.Teachers.Remove(teacher);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Teachers/Index");
    }
}
