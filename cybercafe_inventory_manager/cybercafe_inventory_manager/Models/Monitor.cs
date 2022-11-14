using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Monitor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string brand { get; set; }
        [MaxLength(20)]
        [Required]
        public string model { get; set; }
        [MaxLength(20)]
        [Required]
        public string screen_resolution { get; set; }
        [Required]
        public string ports_and_types { get; set; }
    }
}
