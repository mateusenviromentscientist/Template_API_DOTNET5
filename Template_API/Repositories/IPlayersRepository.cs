using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template_API.Dto;
using Template_API.Models;

namespace Template_API.Repositories
{
    public interface IPlayersRepository
    {
        public Task<IEnumerable<PlayersModel>> GetPlayers();
        public Task<PlayersModel> GetPlayer(int id);
        public Task<PlayersModel> CreatePlayer(PlayerForCreationDto player);
        public Task UpdatePlayer(int id,PlayerUpdateDto player);
        public Task DeletePlayer(int id);
    }
}