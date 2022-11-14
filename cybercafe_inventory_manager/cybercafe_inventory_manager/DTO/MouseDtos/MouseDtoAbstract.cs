using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.DTO.MouseDtos
{
    public class MouseDtoAbstract:Profile
    {
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
