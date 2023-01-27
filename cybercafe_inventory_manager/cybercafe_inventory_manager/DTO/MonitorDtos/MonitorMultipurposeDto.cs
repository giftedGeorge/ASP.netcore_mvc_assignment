using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.MonitorDtos
{
    [AutoMap(typeof(Monitor), ReverseMap = true)]
    public class MonitorMultipurposeDto:MonitorDtoAbstract
    {
    }
}
