using System.Data.SqlClient;

namespace Leilum.Data
{
    internal class DAOConfig
    {
        private const string USER = "leilum";
        private const string PASSWORD = "leilum";
        //public const string MACHINE = "";
        private const string DATABASE = "LEILUM";


        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder();
            //conn.DataSource = MACHINE;
            conn.UserID = USER;
            conn.Password = PASSWORD;
            conn.InitialCatalog = DATABASE;
            conn.TrustServerCertificate = true;
            
            return conn.ConnectionString;
        }

    }

}