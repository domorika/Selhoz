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

        // GET: Открывает страницу добавления сотрудника
        [Authorize(Roles = "Agronom,Director")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Сохраняет нового сотрудника в правильную таблицу базы данных
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create(Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Workers.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }
    }
}