using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    [Authorize]
    public class FieldsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FieldsController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var fields = await _context.Fields.ToListAsync();
            return View(fields);
        }

        [Authorize(Roles = "Agronom,Director")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create(Field field)
        {
            if (ModelState.IsValid)
            {
                _context.Fields.Add(field);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(field);
        }
    }
}