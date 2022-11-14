using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.Models
{
    public class Mouse
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
        public string type { get; set; }
        [MaxLength(20)]
        public string colour { get; set; }
    }
}
