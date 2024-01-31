using System.Data.SqlClient;

namespace Leilum.Data
{
    internal class DAOConfig
    {
        private const string USER = "leilum";
        private const string PASSWORD = "leilum";

        private const string SERVER = "localhost"; 
        private const string PORT = "1401"; 
        private const string DATABASE = "LEILUM";


        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            conn.DataSource = $"{SERVER}";
            conn.UserID = USER;
            conn.Password = PASSWORD;
            conn.InitialCatalog = DATABASE;
            conn.TrustServerCertificate = true;
            
            return conn.ConnectionString;
        }

    }

}