using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Modules;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Module Module { get; set; }
    public List<Module> Modules { get; set; }




    public async Task OnGet()
        => Modules = await _db.Modules.ToListAsync();




    public async Task<IActionResult> OnPostCreate()
    {
        await _db.Modules.AddAsync(Module);
        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
