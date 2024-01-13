using System.Data.SqlClient;

namespace Leilum.Data
{
    internal class DAOConfig
    {
        public const string USER = "";
        public const string PASSWORD = "";
        public const string MACHINE = "";
        public const string DATABASE = "LEILUM";


        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = MACHINE;
            conn.UserID = USER;
            conn.Password = PASSWORD;
            conn.InitialCatalog = DATABASE;
            conn.TrustServerCertificate = true;
            
            return conn.ConnectionString;
        }

    }

}