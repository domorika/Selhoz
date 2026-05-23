using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var workers = await _context.Workers.ToListAsync();
            return View(workers);
        }

        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Fields = new SelectList(await _context.Fields.ToListAsync(), "Id", "FieldNumber");
            ViewBag.Plants = new SelectList(await _context.Plants.ToListAsync(), "Id", "Name");
            ViewBag.Workers = new SelectList(await _context.Workers.ToListAsync(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create(PlantingJournal record)
        {
            ModelState.Remove("Field"); ModelState.Remove("Plant"); ModelState.Remove("Worker");
            if (ModelState.IsValid)
            {
                _context.PlantingJournal.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }
    }
}