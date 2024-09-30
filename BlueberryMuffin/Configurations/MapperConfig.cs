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
            CreateMap<Country, GetCountry>().ReverseMap();
            CreateMap<Country, CountryDetails>().ReverseMap();

            CreateMap<Hotel, GetHotel>().ReverseMap();
            CreateMap<Hotel, CreateHotel>().ReverseMap();

            CreateMap<AccountDetails, ApiUser>().ReverseMap();
        }
    }
}
