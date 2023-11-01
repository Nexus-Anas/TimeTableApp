using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolApp.Models;

namespace SchoolApp.Pages.Salles;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    public IndexModel(AppDbContext db) => _db = db;




    [BindProperty]
    public Salle Salle { get; set; }
    public List<Salle> Salles { get; set; }




    public async Task OnGet()
        => Salles = await _db.Salles.ToListAsync();




    public async Task<IActionResult> OnPostCreate()
    {
        //for (char letter = 'A'; letter <= 'Z'; letter++)
        //{
        //    for (int number = 1; number <= 3; number++)
        //    {
        //        var salle = new Salle
        //        {
        //            Name = $"{letter}{number}",
        //            nbMaxPlaces = 25
        //        };
        //        await _db.Salles.AddAsync(salle);
        //    }
        //}
        await _db.Salles.AddAsync(Salle);
        await _db.SaveChangesAsync();
        await OnGet();
        return Page();
    }
}
