using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.ComputerDtos
{
    [AutoMap(typeof(Computer))]
    public class ComputerReadDto:ComputerDtoAbstract
    {
        public int Id { get; set; }
    }
}
