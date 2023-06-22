using AutoMapper;
using ClubSquad.Data;
using ClubSquad.Dto;
using ClubSquad.Interfaces;
using ClubSquad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ClubSquad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public TeamController(DataContext context, IMapper mapper, ITeamRepository teamRepository)
        {
            _context = context;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teamData = _teamRepository.GetTeams();
            var team = _mapper.Map<List<TeamResponse>>(teamData);
            return Ok(team);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teamData = _teamRepository.GetTeam(id);
            var team = _mapper.Map<TeamResponse>(teamData);
            return Ok(team);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeamDto teamDto)
        {
            var newTeam = _mapper.Map<Team>(teamDto);
            var team = _teamRepository.CreateTeam(newTeam);

            return Ok(newTeam);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TeamDto teamDto)
        {
            if (id != teamDto.Id)
            {
                return BadRequest("not eyni");
            }

            var teamMap = _mapper.Map<Team>(teamDto);


            return Ok(teamMap);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var team = _teamRepository.GetTeam(id);
            _teamRepository.DeleteTeam(team);
            return Ok(team);
        }
    }
}