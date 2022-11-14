using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace cybercafe_inventory_manager.DTO.MonitorDtos
{
    public class MonitorDtoAbstract:Profile
    {
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
