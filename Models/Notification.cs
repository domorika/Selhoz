namespace Selhoz.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;   // Id пользователя из Identity
        public bool IsRead { get; set; } = false;
        public string Type { get; set; } = "Info"; // Info, Warning, Success, Error
    }
}