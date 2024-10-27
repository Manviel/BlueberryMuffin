using AutoMapper;
using BlueberryMuffin.Data;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Survey, GetSurvey>().ReverseMap();
            CreateMap<Survey, SurveyDetails>().ReverseMap();

            CreateMap<Question, GetQuestion>().ReverseMap();

            CreateMap<AccountDetails, ApiUser>().ReverseMap();
        }
    }
}
