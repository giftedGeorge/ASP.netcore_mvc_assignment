using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.KeyboardDtos
{
    [AutoMap(typeof(Keyboard))]
    public class KeyboardReadDto:KeyboardDtoAbstract
    {
        public int Id { get; set; }
    }
}
