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
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayerController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<PlayerDto> Get()
        {
            var playerData = _context.Players.ToList();
            var player = _mapper.Map<List<PlayerDto>>(playerData);
            return Ok(player);
        }
        [HttpGet("{id}")]
        public ActionResult<PlayerDto> Get(int id)
        {
            var playerId = _context.Players.Where(n => n.Id == id).FirstOrDefault();
            var player = _mapper.Map<PlayerDto>(playerId);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }

        [HttpPost]
        public ActionResult<PlayerDto> Create(PlayerDto playerDto)
        {
            Player player = new Player();
            player.Name = playerDto.Name;
            player.Surname = playerDto.Surname;
            player.Age = playerDto.Age;
            player.TeamId = playerDto.TeamId;

            _context.Players.Add(player);
            _context.SaveChanges();
            return Ok(_context.Players.ToList());
        }
        [HttpPut]
        public ActionResult<PlayerDto> Update(PlayerDto playerDto, int id)
        {
            Player player = _context.Players.Find(id);
            player.Name = playerDto.Name;
            player.Surname = playerDto.Surname;
            player.Age = playerDto.Age;

            _context.SaveChanges();
            return Ok(playerDto);
        }

        [HttpDelete]
        public ActionResult<PlayerDto> Delete(int id)
        {
            PlayerDto playerDto = new PlayerDto();
            Player player = _context.Players.Find(id);

            playerDto.Name = player.Name;
            playerDto.Surname = player.Surname;
            playerDto.Age = player.Age;

            _context.Players.Remove(player);
            _context.SaveChanges();
            return Ok(playerDto);
        }
    }
}
