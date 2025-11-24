using MySql.Data.MySqlClient;
using System.Configuration;

namespace Course_Project.Database
{
    internal static class Db
    {
        public static MySqlConnection Connection()
        {
            string path = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            return new MySqlConnection(path);
        }
    }
}
