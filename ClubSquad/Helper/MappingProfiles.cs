using AutoMapper;
using ClubSquad.Dto;
using ClubSquad.Models;

namespace ClubSquad.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Team, TeamDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<Team, TeamResponse>();
            CreateMap<TeamResponse, Team>();
            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerResponse, Player>();

        }
    }
}