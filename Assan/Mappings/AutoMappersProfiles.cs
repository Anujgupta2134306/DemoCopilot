using Assan.Domain;
using Assan.DTO;
using AutoMapper;

namespace Assan.Mappings
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles() 
        {
            CreateMap<Player, PlayersDto>().ReverseMap();
            CreateMap<AddPlayerRequestDto, Player>().ReverseMap();


        }
    }
}
