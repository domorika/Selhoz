namespace Selhoz.Models
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = "Info";
        public bool IsRead { get; set; }
    }
}