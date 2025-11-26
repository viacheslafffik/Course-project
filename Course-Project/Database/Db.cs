using MySql.Data.MySqlClient;
using System.Configuration;

namespace Course_Project.Database
{
    internal static class Db
    {
        public static MySqlConnection Connection()
        {
            return new MySqlConnection(ConfigurationManager
                .ConnectionStrings["MyDb"].ConnectionString);
        }
    }
}
