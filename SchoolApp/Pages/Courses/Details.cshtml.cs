using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _db;
        public DetailsModel(AppDbContext db) => _db = db;




        [BindProperty]
        public Course Course { get; set; }
        public List<Module> Modules { get; set; }

        public bool check_course_presence;




        public async Task OnGet(int id)
        {
            Course = await _db.Courses.FindAsync(id);
            Modules = await _db.Modules.ToListAsync();
        }




        public async Task<IActionResult> OnPostUpdate()
        {
            var course = await _db.Courses.FindAsync(Course.Id);
            course.Name = Course.Name;
            course.NbHour = Course.NbHour;
            course.ModuleId = Course.ModuleId;
            await _db.SaveChangesAsync();
            return RedirectToPage("/Courses/Index");
        }




        public async Task<IActionResult> OnPostDelete()
        {
            var course = await _db.Courses.FindAsync(Course.Id);

            if (course is null)
                return NotFound();

            var teacherId = await _db.Teachers.Where(t => t.Course.Id == course.Id).Select(x => x.Id).FirstOrDefaultAsync();

            if (teacherId != 0)
            {
                check_course_presence = true;
                return Page();
            }

            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Courses/Index");
        }
    }
}
