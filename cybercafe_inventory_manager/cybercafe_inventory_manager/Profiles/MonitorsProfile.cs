using AutoMapper;
using cybercafe_inventory_manager.DTO.MonitorDtos;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.Profiles
{
    public class MonitorsProfile:Profile
    {
        public MonitorsProfile()
        {
            CreateMap<Monitor, MonitorMultipurposeDto>().ReverseMap();
            CreateMap<Monitor, MonitorReadDto>().ReverseMap();
        }
    }
}
