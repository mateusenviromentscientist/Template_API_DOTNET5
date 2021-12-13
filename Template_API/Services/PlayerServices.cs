using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template_API.Dto;
using Template_API.Models;
using Template_API.Repositories;

namespace Template_API.Services
{
    public class PlayerServices : ControllerBase, IPlayerServices
    {
        private readonly IPlayersRepository _repository;

        public PlayerServices(IPlayersRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<PlayersModel>> GetPlayers()
        {
            var players = await _repository.GetPlayers();
            if (players == null)
                NotFound();
            return players;

        }

        public async Task<PlayersModel> GetPlayerById(int id)
        {
            var player = await _repository.GetPlayer(id);
            if (player == null)
                NotFound();
            return player;
        }

        public async Task<CreatedAtRouteResult> CreatePlayer(PlayerForCreationDto player)
        {
            var createdPlayer = await _repository.CreatePlayer(player);
            if (createdPlayer == null)
                NotFound();
            return CreatedAtRoute("PlayerById", new { id = createdPlayer.Id }, createdPlayer);
        }

        public async Task<NoContentResult> UpdatePlayer(int id, PlayerUpdateDto player)
        {
            var updatePlayer = await _repository.GetPlayer(id);
            if (updatePlayer == null)
                NotFound();
            await _repository.UpdatePlayer(id, player);
            return NoContent();
        }

        public async Task<NoContentResult> DeletePlayer(int id)
        {
            var deletedPlayer = await _repository.GetPlayer(id);
            if (deletedPlayer == null)
                NotFound();
            await _repository.DeletePlayer(id);
            return NoContent();
        }
    }
}