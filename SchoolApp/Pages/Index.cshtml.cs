using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public int Salles { get; set; }
        public int Teachers { get; set; }
        public int Groups { get; set; }
        public int Modules { get; set; }
        public async Task OnGet()
        {
            Salles = await _db.Salles.CountAsync();
            Teachers = await _db.Teachers.CountAsync();
            Groups = await _db.Groups.CountAsync();
            Modules = await _db.Modules.CountAsync();
        }
    }
}