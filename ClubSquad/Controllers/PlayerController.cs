using AutoMapper;
using ClubSquad.Data;
using ClubSquad.Dto;
using ClubSquad.Interfaces;
using ClubSquad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClubSquad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(DataContext context,IMapper mapper, IPlayerRepository playerRepository)
        {
            _context = context;
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var playerData = await _playerRepository.GetPlayer();
            var player = _mapper.Map<List<PlayerResponse>>(playerData);
            return Ok(player);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var playerId = await _playerRepository.GetPlayers(id);
            var player = _mapper.Map<PlayerResponse>(playerId);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]PlayerResponse playerDto)
        {
            var playerMap = _mapper.Map<Player>(playerDto);
            await _playerRepository.CreatePlayer(playerMap);
            return Ok(playerMap);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]PlayerDto playerDto, int id)
        {
            if (playerDto is null)
            {
                return BadRequest("bad");
            }

            if (id != playerDto.Id)
            {
                return BadRequest("Not found");
            }

            var playerMap = _mapper.Map<Player>(playerDto);

            await _playerRepository.UpdatePlayer(playerMap);
           
            return Ok(playerMap);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var player = await _playerRepository.GetPlayers(id);
            await _playerRepository.DeletePlayer(player);
            return Ok(player);
        }
    }
}