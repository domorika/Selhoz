using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;
using System.Linq;
using System.Threading.Tasks;

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

        // Вывод списка с фильтрацией по статусу (Посадка/Полив/Сбор)
        public async Task<IActionResult> Index(string statusFilter)
        {
            var query = _context.PlantingJournals
                .Include(p => p.Field)
                .Include(p => p.Plant)
                .Include(p => p.Worker)
                .AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.FilterByStatus(statusFilter); // Использование расширения бизнес-логики
            }

            return View(await query.ToListAsync());
        }

        // Создание нового наряда-записи (Разрешено только Агроному-администратору)
        [Authorize(Roles = "Agronomist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FieldId,PlantId,WorkerId,PlantingDate,SeedAmount,Status")] PlantingJournal record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }
    }
}