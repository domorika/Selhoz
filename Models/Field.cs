using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selhoz.Models
{
    [Table("fields")]
    public class Field
    {
        [Key]
        [Column("field_id")]
        public int FieldId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("field_name")]
        public string FieldName { get; set; } = string.Empty;

        [Required]
        [Column("area")]
        public decimal Area { get; set; }

        [StringLength(30)]
        [Column("soil_type")]
        public string SoilType { get; set; } = string.Empty;

        [Column("irrigation")]
        public bool Irrigation { get; set; }

        [StringLength(30)]
        [Column("last_crop")]
        public string LastCrop { get; set; } = string.Empty;
    }
}