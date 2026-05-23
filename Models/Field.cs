namespace Selhoz.Models
{
    public class Field
    {
        public int Id { get; set; }

        public string FieldNumber { get; set; } = string.Empty;     // Номер поля
        public decimal Area { get; set; }                           // Площадь в гектарах
        public string SoilType { get; set; } = string.Empty;        // Тип почвы
        public string IrrigationType { get; set; } = string.Empty;  // Тип полива
        public string Location { get; set; } = string.Empty;        // Местоположение

        // Навигационные свойства
        public ICollection<PlantingJournal> PlantingJournals { get; set; } = new List<PlantingJournal>();
    }
}