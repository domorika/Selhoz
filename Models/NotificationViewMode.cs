using System;

namespace Selhoz.Models
{
    public class NotificationViewModel
    {
        public string Type { get; set; } = "Задача";
        public string Description { get; set; } = string.Empty;
        public string StatusText { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsCritical { get; set; } = false;

        public string BadgeClass
        {
            get
            {
                return Type switch
                {
                    "Критическое" => "bg-danger",
                    "Предупреждение" => "bg-warning",
                    "Задача" => "bg-info",
                    _ => "bg-secondary"
                };
            }
        }
    }
}