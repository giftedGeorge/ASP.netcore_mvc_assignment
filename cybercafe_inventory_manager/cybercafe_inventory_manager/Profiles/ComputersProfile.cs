using AutoMapper;
using cybercafe_inventory_manager.DTO.ComputerDtos;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.Profiles
{
    public class ComputersProfile:Profile
    {
        public ComputersProfile()
        {
            CreateMap<Computer, ComputerMultipurposeDto>().ReverseMap();
            CreateMap<Computer, ComputerReadDto>().ReverseMap();
        }
    }
}
