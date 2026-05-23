// Models/PlantingJournal.cs
using Selhoz.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selhoz.Models
{
    [Table("plantingjournal")]
    public class PlantingJournal
    {
        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }

        [Column("field_id")]
        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public Field Field { get; set; }

        [Column("plant_id")]
        public int PlantId { get; set; }
        [ForeignKey("PlantId")]
        public Plant Plant { get; set; }

        [Column("worker_id")]
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("planting_date")]
        public DateTime PlantingDate { get; set; }

        [DataType(DataType.Date)]
        [Column("harvest_date")]
        public DateTime? HarvestDate { get; set; }

        [Column("seed_amount", TypeName = "numeric(3,2)")]
        public decimal SeedAmount { get; set; }

        [Required]
        [StringLength(30)]
        [Column("status")]
        public string Status { get; set; } // "Посадка", "Полив", "Сбор"
    }
}