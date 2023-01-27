using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Computer:ModelsAbstract
    {
        [Required]
        public float processor_speed { get; set; }
        [Required]
        public int number_of_cores { get; set; }
        [Required]
        public int number_of_usb_ports { get; set; }
        [Required]
        public int number_of_hdmi_ports { get; set; }
        [Required]
        public int quantity { get; set; }
        [MaxLength(100)]
        public string notes { get; set; }
    }
}
