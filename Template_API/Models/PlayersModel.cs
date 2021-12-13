using System.Collections.Generic;

namespace Template_API.Models
{
    public class PlayersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set;}
        public List<TeamsModel> Teams { get; set; } = new List<TeamsModel>();
    }
}