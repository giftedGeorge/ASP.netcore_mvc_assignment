using AutoMapper;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.DTO.ComputerDtos
{
    [AutoMap(typeof(Computer), ReverseMap = true)]
    public class ComputerMultipurposeDto:ComputerDtoAbstract
    {
    }
}
