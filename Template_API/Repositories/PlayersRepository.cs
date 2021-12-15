using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Template_API.Context;
using Template_API.Models;
using Dapper;
using Template_API.Dto;

namespace Template_API.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly DapperContext _context;

        public PlayersRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayersModel>> GetPlayers()
        {
            var query = "SELECT  Id,Name,Country FROM PLAYERS";
            using (var connection = _context.CreateConnection())
            {
                var players = await connection.QueryAsync<PlayersModel>(query);
                return players.ToList();
            }
        }

        public async Task<PlayersModel> GetPlayer(int id)
        {
            var query = "SELECT * FROM Players WHERE Id = @Id";


            using (var connection = _context.CreateConnection())
            {

                var player = await connection.QuerySingleOrDefaultAsync<PlayersModel>(query, new {id});
                
                return player;
            }
            
        }

        public async Task<PlayersModel> CreatePlayer(PlayerForCreationDto player)
        {
            var query = "INSERT INTO Players (Name, Country) VALUES (@Name, @Country)" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";
            var paramaters = new DynamicParameters();
            paramaters.Add("Name", player.Name, DbType.String);
            paramaters.Add("Country", player.Country, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, paramaters);
                var createPlayer = new PlayersModel
                {
                    Id = id,
                    Name = player.Name,
                    Country = player.Country
                };
                return createPlayer;
            }
        }

        public async Task UpdatePlayer(int id, PlayerUpdateDto player)
        {
            var query = "UPDATE Players SET Name = @Name, Country = @Country WHERE Id = @Id";
            var paramaters = new DynamicParameters();
            paramaters.Add("Id", id, DbType.Int32);
            paramaters.Add("Name", player.Name, DbType.String);
            paramaters.Add("Country", player.Country, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeletePlayer(int id)
        {
            var query = "DELETE FROM Players WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}