using AutoMapper;
using cybercafe_inventory_manager.DTO.RouterDtos;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.Profiles
{
    public class RoutersProfile:Profile
    {
        public RoutersProfile()
        {
            CreateMap<Router, RouterMultipurposeDto>().ReverseMap();
            CreateMap<Router, RouterReadDto>().ReverseMap();
        }
    }
}
