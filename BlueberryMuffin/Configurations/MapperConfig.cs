using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountry>().ReverseMap();
        }
    }
}
