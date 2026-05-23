using Microsoft.AspNetCore.Mvc;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var notifications = new List<NotificationViewModel>
            {
                new NotificationViewModel { Type = "Критическое", Description = "Низкий уровень азота на поле №3", StatusText = "Требует внимания", IsCritical = true },
                new NotificationViewModel { Type = "Задача", Description = "Посадка пшеницы на поле №5", StatusText = "В работе", CreationDate = DateTime.Now.AddHours(-2) },
                new NotificationViewModel { Type = "Предупреждение", Description = "Скоро сбор урожая на поле №2", StatusText = "Подготовка" }
            };

            return View(notifications);
        }
    }
}