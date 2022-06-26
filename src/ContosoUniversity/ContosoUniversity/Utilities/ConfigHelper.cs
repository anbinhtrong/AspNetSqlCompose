namespace ContosoUniversity.Utilities
{
    public class ConfigHelper
    {
        public static string GetConnectionString(string servername, string databaseName, string user, string password, int timeout = 30)
        {
            return $"Server={servername};Initial Catalog={databaseName};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=True;Connection Timeout=30;";
        }
    }
}
