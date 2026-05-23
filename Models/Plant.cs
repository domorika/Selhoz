using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selhoz.Models
{
    [Table("plants")]
    public class Plant
    {
        [Key]
        [Column("plant_id")]
        public int PlantId { get; set; }

        [Required]
        [StringLength(30)]
        [Column("plant_name")]
        public string PlantName { get; set; } = string.Empty;

        [StringLength(30)]
        [Column("plant_type")]
        public string PlantType { get; set; } = string.Empty;

        [Column("growth_period")]
        public int GrowthPeriod { get; set; }

        [StringLength(30)]
        [Column("water_requirements")]
        public string WaterRequirements { get; set; } = string.Empty;

        [StringLength(30)]
        [Column("climate_zone")]
        public string ClimateZone { get; set; } = string.Empty;
    }
}