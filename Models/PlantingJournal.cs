using System.Text.RegularExpressions;

namespace Selhoz.Models
{
    public class PlantingJournal
    {
        public int Id { get; set; }

        public int FieldId { get; set; }
        public Field? Field { get; set; }

        public int CultureId { get; set; }
        public Plant? Plant { get; set; }

        public int WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public DateTime PlantingDate { get; set; }
        public DateTime? HarvestDate { get; set; }

        public string Status { get; set; } = "Посажено"; // Посажено, Созревает, Собрано, Проблема

        public string Notes { get; set; } = string.Empty;
    }
}