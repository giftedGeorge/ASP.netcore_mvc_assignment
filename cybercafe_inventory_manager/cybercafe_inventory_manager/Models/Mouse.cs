using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Mouse:ModelsAbstract
    {
        [MaxLength(20)]
        [Required]
        public string model { get; set; }
        [MaxLength(20)]
        [Required]
        public string type { get; set; }
        [MaxLength(20)]
        public string colour { get; set; }
    }
}
