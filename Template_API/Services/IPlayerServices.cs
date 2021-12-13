using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template_API.Dto;
using Template_API.Models;

namespace Template_API.Services
{
    public interface IPlayerServices
    {
        Task<CreatedAtRouteResult> CreatePlayer(PlayerForCreationDto player);
        Task<NoContentResult> DeletePlayer(int id);
        Task<PlayersModel> GetPlayerById(int id);
        Task<IEnumerable<PlayersModel>> GetPlayers();
        Task<NoContentResult> UpdatePlayer(int id, PlayerUpdateDto player);
    }
}