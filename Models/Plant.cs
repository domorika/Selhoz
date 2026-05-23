namespace Selhoz.Models
{
    public class Plant
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;                    // Название культуры
        public int GrowthPeriodDays { get; set; }                           // Период роста (дней)
        public string ClimateRequirements { get; set; } = string.Empty;     // Требования к климату
        public string WaterRequirements { get; set; } = string.Empty;       // Требования к поливу
        public string Type { get; set; } = string.Empty;

        public ICollection<PlantingJournal> PlantingJournals { get; set; } = new List<PlantingJournal>();
    }
}