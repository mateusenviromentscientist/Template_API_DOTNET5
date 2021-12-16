namespace Template_API.Scripts
{
    public static class Queries
    {
        public static string GetPlayers()
        {
            return "SELECT  Id,Name,Country FROM PLAYERS";
        }

        public static string GetPlayersById()
        {
            return "SELECT * FROM Players WHERE Id = @Id";
        }

        public static string CreatePlayers()
        {
            return "INSERT INTO Players (Name, Country) VALUES (@Name, @Country)" +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";
        }

        public static string UpdatePlayers()
        {
            return "UPDATE Players SET Name = @Name, Country = @Country WHERE Id = @Id";
        }

        public static string DeletePlayers()
        {
            return "DELETE FROM Players WHERE Id = @Id";
        }
    }
}
