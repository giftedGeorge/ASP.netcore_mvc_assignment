using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.RouterDtos
{
    [AutoMap(typeof(Router))]
    public class RouterReadDto:RouterDtoAbstract
    {
        public int Id { get; set; }
    }
}
