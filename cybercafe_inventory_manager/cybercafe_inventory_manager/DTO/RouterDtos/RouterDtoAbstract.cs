using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.DTO.RouterDtos
{
    public class RouterDtoAbstract:Profile
    {
        [MaxLength(20)]
        [Required]
        public string brand { get; set; }
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
