// Controllers/PlantingJournalController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;
namespace SelhozApp.Controllers
{
    [Authorize]
    public class PlantingJournalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantingJournalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Просмотр журнала с возможностью фильтрации
        public async Task<IActionResult> Index(string currentStatus)
        {
            var journalRecords = _context.PlantingJournals
                .Include(p => p.Field)
                .Include(p => p.Plant)
                .Include(p => p.Worker)
                .AsQueryable();

            if (!string.IsNullOrEmpty(currentStatus))
            {
                journalRecords = journalRecords.Where(j => j.Status == currentStatus);
            }

            return View(await journalRecords.ToListAsync());
        }

        // Формирование наряда (Доступ имеет только Агроном-администратор)
        [Authorize(Roles = "Agronomist")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Agronomist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FieldId,PlantId,WorkerId,PlantingDate,Status")] PlantingJournal plantingRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantingRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantingRecord);
        }
    }
}