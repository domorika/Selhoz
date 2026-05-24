using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;
using System.Security.Claims;

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
                string userRole = User.IsInRole("Agronom") ? "Агроном" :
                          User.IsInRole("Director") ? "Директор" : "Сотрудник";

                // 2. Получаем ID текущего пользователя (ему и покажем уведомление)
                string currentUserId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);

                // 3. Формируем само уведомление
                var notification = new Notification
                {
                    Title = "Обновление базы данных",
                    Message = $"{userRole} добавил новую запись в таблицу «Сотрудники».",
                    IsRead = false,
                    UserId = currentUserId,
                    Type = "Info"
                };

                // 4. Добавляем уведомление в базу
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }
    }
}