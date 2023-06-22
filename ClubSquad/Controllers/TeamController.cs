using AutoMapper;
using ClubSquad.Data;
using ClubSquad.Dto;
using ClubSquad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubSquad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeamController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var teamData = _context.Teams.Include(n => n.Players).ToList();
            var team = _mapper.Map<List<TeamResponse>>(teamData);
            return Ok(team);
        }

        [HttpGet("{id}")]
        public ActionResult<TeamResponse> Get(int id)
        {
            var teamData = _context.Teams.Include(_n => _n.Players).Where(n => n.Id == id).FirstOrDefault();
            var team = _mapper.Map<TeamResponse>(teamData);
            return Ok(team);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeamDto teamDto)
        {
            var newTeam = _mapper.Map<Team>(teamDto);
            _context.Teams.Add(newTeam);
            _context.SaveChanges();

            return Created($"/{newTeam.Id}", newTeam);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TeamDto teamDto)
        {
            var team = _context.Teams.Find(id);
            // var updateTeam = _mapper.Map<Team>(team);
            team.Name = teamDto.Name;
            team.Salary = teamDto.Salary;
            _context.Teams.Update(team);
            _context.SaveChanges();

            return Ok(team);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Team player = _context.Teams.Find(id);
            var newTeam = _mapper.Map<Team>(player);

            _context.Teams.Remove(player);
            _context.SaveChanges();
            return Ok(newTeam);
        }
    }
}