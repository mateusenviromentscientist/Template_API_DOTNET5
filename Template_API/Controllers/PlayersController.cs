using System;
using System.Threading.Tasks;
using Template_API.Dto;
using Microsoft.AspNetCore.Mvc;
using Template_API.Services;

namespace Template_API.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly IPlayerServices _services;

        public PlayersController( IPlayerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult> GetPlayers()
        {
            try
            {
                var players = await _services.GetPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "PlayerById")]
        public async Task<IActionResult> GetPlayers(int id)
        {
            try
            {
                var player = await _services.GetPlayerById(id);
                return Ok(player);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayers(PlayerForCreationDto player)
        {
            try
            {
                var createdPlayer = await _services.CreatePlayer(player);
                return Ok(createdPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayers(int id, PlayerUpdateDto player)
        {
            try
            {
                var dbPlayers = await _services.UpdatePlayer(id,player);
                return Ok(dbPlayers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayers(int id)
        {
            try
            {
                var dbPlayer = await _services.DeletePlayer(id);
                return Ok(dbPlayer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}