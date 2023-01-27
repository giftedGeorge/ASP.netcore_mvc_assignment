using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Monitor:ModelsAbstract
    {
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
