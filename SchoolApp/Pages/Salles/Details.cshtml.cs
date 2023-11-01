using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages.Salles;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;
    public DetailsModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Salle Salle { get; set; }

    public bool check_salle_presence;




    public async Task OnGet(int id)
        => Salle = await _db.Salles.FindAsync(id);




    public async Task<IActionResult> OnPostUpdate()
    {
        var salle = await _db.Salles.FindAsync(Salle.Id);
        salle.Name = Salle.Name;
        salle.nbMaxPlaces = Salle.nbMaxPlaces;
        await _db.SaveChangesAsync();
        return RedirectToPage("/Salles/Index");
    }




    public async Task<IActionResult> OnPostDelete()
    {
        var salle = await _db.Salles.FindAsync(Salle.Id);

        if (salle is null)
            return NotFound();

        var groupId = await _db.Groups.Where(g => g.SalleId == salle.Id).Select(x => x.Id).FirstOrDefaultAsync();

        if (groupId != 0)
        {
            check_salle_presence = true;
            return Page();
        }

        _db.Salles.Remove(salle);
        await _db.SaveChangesAsync();
        return RedirectToPage("/Salles/Index");
    }
}
