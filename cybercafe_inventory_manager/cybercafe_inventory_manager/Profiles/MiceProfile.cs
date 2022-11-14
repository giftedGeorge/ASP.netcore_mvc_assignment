using AutoMapper;
using cybercafe_inventory_manager.DTO.MouseDtos;
using cybercafe_inventory_manager.Models;

namespace cybercafe_inventory_manager.Profiles
{
    public class MiceProfile:Profile
    {
        public MiceProfile()
        {
            CreateMap<Mouse, MouseMultipurposeDto>().ReverseMap();
            CreateMap<Mouse, MouseReadDto>().ReverseMap();
        }
    }
}
