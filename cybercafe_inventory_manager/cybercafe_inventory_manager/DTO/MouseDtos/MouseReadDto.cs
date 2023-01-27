using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.MouseDtos
{
    [AutoMap(typeof(Mouse))]
    public class MouseReadDto:MouseDtoAbstract
    {
        public int Id { get; set; }
    }
}
