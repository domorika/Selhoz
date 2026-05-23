using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    [Authorize]
    public class PlantingJournalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantingJournalController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var journal = await _context.PlantingJournal
                .Include(j => j.Field)
                .Include(j => j.Plant)
                .Include(j => j.Worker)
                .ToListAsync();
            return View(journal);
        }
    }
}