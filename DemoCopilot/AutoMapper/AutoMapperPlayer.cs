using AutoMapper;
using DemoCopilot.Model.Domain;
using DemoCopilot.Model.Dto;

namespace DemoCopilot.AutoMapper
{
    public class AutoMapperPlayer : Profile
    {
        public AutoMapperPlayer()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Player, PlayerRequestDto>().ReverseMap();


        }
    }
}
