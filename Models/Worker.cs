using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selhoz.Models
{
    [Table("workers")]
    public class Worker
    {
        [Key]
        [Column("worker_id")]
        public int WorkerId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        [Column("position")]
        public string Position { get; set; } = string.Empty;

        [StringLength(13)]
        [Column("contact_phone")]
        public string ContactPhone { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("qualification")]
        public string Qualification { get; set; } = string.Empty;
    }
}