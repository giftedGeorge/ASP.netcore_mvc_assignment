using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.KeyboardDtos
{
    [AutoMap(typeof(Keyboard),ReverseMap =true)]
    public class KeyboardMultipurposeDto:KeyboardDtoAbstract
    {
    }
}
