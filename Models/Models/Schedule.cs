using System.ComponentModel.DataAnnotations;

namespace MVCAnri.Models
{
    public class Schedule
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; } = string.Empty;

    }
}
