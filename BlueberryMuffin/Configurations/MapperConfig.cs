using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Survey, CreateSurvey>().ReverseMap();
            CreateMap<Survey, GetSurvey>().ReverseMap();
            CreateMap<Survey, SurveyDetails>().ReverseMap();

            CreateMap<Hotel, GetHotel>().ReverseMap();
            CreateMap<Hotel, CreateHotel>().ReverseMap();

            CreateMap<AccountDetails, ApiUser>().ReverseMap();
        }
    }
}
