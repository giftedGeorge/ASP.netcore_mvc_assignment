using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Router:ModelsAbstract
    {
        [MaxLength(20)]
        [Required]
        public string model { get; set; }
        [MaxLength(20)]
        [Required]
        public string service_provider { get; set; }
        [MaxLength(20)]
        public string colour { get; set; }
        [Required]
        public int quantity { get; set; }
    }
}
