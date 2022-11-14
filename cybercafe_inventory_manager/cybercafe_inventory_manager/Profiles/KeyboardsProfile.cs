using cybercafe_inventory_manager.Models;
using AutoMapper;
using cybercafe_inventory_manager.DTO.KeyboardDtos;

namespace cybercafe_inventory_manager.Profiles
{
    public class KeyboardsProfile:Profile
    {
        public KeyboardsProfile()
        {
            CreateMap<Keyboard, KeyboardMultipurposeDto>().ReverseMap();
            CreateMap<Keyboard, KeyboardReadDto>().ReverseMap();
        }
    }
}
