using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Selhoz.Data;
using Selhoz.Models;

namespace Selhoz.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var notifications = await _context.Notifications
                .Where(n => n.UserId == user.Id && !n.IsRead)
                .OrderByDescending(n => n.Date)
                .Select(n => new NotificationViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Message = n.Message,
                    Date = n.Date,
                    Type = n.Type,
                    IsRead = n.IsRead
                })
                .ToListAsync();

            ViewBag.UserRoles = await _userManager.GetRolesAsync(user);

            return View(notifications);   // ← Важно: NotificationViewModel
        }
    }
}