namespace Selhoz.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;        // Должность (Агроном, Тракторист и т.д.)
        public string Phone { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;

        public ICollection<PlantingJournal> PlantingJournals { get; set; } = new List<PlantingJournal>();
    }
}