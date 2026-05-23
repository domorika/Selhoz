// Models/Field.cs
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

        [Required(ErrorMessage = "Название поля обязательно")]
        [StringLength(150)]
        [Column("field_name")]
        public string FieldName { get; set; }

        [Required]
        [Column("area", TypeName = "numeric(3,2)")]
        public decimal Area { get; set; }

        [StringLength(30)]
        [Column("soil_type")]
        public string SoilType { get; set; }

        [Column("irrigation")]
        public bool Irrigation { get; set; }

        [StringLength(30)]
        [Column("last_crop")]
        public string LastCrop { get; set; }
    }
}