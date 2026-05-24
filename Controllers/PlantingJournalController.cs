using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;
using System.Security.Claims;

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

        // GET: Отображение формы создания
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Fields = new SelectList(await _context.Fields.ToListAsync(), "Id", "FieldNumber");
            ViewBag.Plants = new SelectList(await _context.Plants.ToListAsync(), "Id", "Name");
            ViewBag.Workers = new SelectList(await _context.Workers.ToListAsync(), "Id", "FullName");
            return View();
        }

        // POST: Сохранение данных
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agronom,Director")]
        public async Task<IActionResult> Create(PlantingJournal record)
        {
            // Очищаем ошибки валидации для навигационных свойств, так как они заполняются EF автоматически
            ModelState.Remove("Field");
            ModelState.Remove("Plant");
            ModelState.Remove("Worker");

            if (ModelState.IsValid)
            {
                _context.PlantingJournal.Add(record);
                string userRole = User.IsInRole("Agronom") ? "Агроном" :
                          User.IsInRole("Director") ? "Директор" : "Сотрудник";

                // 2. Получаем ID текущего пользователя (ему и покажем уведомление)
                string currentUserId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);

                // 3. Формируем само уведомление
                var notification = new Notification
                {
                    Title = "Обновление базы данных",
                    Message = $"{userRole} добавил новую запись в таблицу «Журнал посевов».",
                    IsRead = false,
                    UserId = currentUserId,
                    Type = "Info"
                };

                // 4. Добавляем уведомление в базу
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Если ошибка, возвращаем списки снова
            ViewBag.Fields = new SelectList(await _context.Fields.ToListAsync(), "Id", "FieldNumber");
            ViewBag.Plants = new SelectList(await _context.Plants.ToListAsync(), "Id", "Name");
            ViewBag.Workers = new SelectList(await _context.Workers.ToListAsync(), "Id", "FullName");
            return View(record);
        }
    }
}