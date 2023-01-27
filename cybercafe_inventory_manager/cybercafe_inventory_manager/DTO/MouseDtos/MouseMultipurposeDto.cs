using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.MouseDtos
{
    [AutoMap(typeof(Mouse), ReverseMap = true)]
    public class MouseMultipurposeDto:MouseDtoAbstract
    {
    }
}
