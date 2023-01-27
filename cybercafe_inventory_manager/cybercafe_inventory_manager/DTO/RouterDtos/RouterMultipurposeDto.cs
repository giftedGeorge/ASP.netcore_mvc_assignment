using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.RouterDtos
{
    [AutoMap(typeof(Router), ReverseMap = true)]
    public class RouterMultipurposeDto:RouterDtoAbstract
    {        
    }
}
