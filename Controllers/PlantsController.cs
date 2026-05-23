using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    [Authorize]
    public class PlantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantsController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var plants = await _context.Plants.ToListAsync();
            return View(plants);
        }

        [Authorize(Roles = "Agronom,Director")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create(Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Plants.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plant);
        }
    }
}