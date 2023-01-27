using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.MonitorDtos
{
    [AutoMap(typeof(Monitor))]
    public class MonitorReadDto:MonitorDtoAbstract
    {
        public int Id { get; set; }
    }
}
