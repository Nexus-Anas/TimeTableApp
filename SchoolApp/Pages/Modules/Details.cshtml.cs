using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Modules;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public DetailsModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Module Module { get; set; }

    public bool check_module_presence;




    public async Task OnGet(int id)
        => Module = await _db.Modules.FindAsync(id);




    public async Task<IActionResult> OnPostUpdate()
    {
        var module = await _db.Modules.FindAsync(Module.Id);
        module.Name = Module.Name;
        await _db.SaveChangesAsync();
        return RedirectToPage("/Modules/Index");
    }




    public async Task<IActionResult> OnPostDelete()
    {
        var module = await _db.Modules.FindAsync(Module.Id);

        if (module is null)
            return NotFound();

        var courseId = await _db.Courses.Where(c => c.Module.Id == module.Id).Select(x => x.Id).FirstOrDefaultAsync();
        var groupId = await _db.Groups.Where(g => g.Module.Id == module.Id).Select(x => x.Id).FirstOrDefaultAsync();
        
        if (courseId != 0 || groupId != 0)
        {
            check_module_presence = true;
            return Page();
        }

        _db.Modules.Remove(module);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Modules/Index");
    }
}
