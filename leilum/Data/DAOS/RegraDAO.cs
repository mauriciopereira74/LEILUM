using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.CategoriaLN;

namespace Leilum.Data.DAOS
{
    internal class RegraDAO
    {
        private static RegraDAO? singleton = null;

        public static RegraDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new RegraDAO();
            }
            return singleton;
        }

        public Regra? get(int idRegra)
        {
            Regra? result = null;
            string sql_cmd = $"SELECT * FROM Regra WHERE idRegra = '{idRegra}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,con)){
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int id_Regra = Convert.ToInt32(reader["idRegra"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorMaximo = Convert.ToDouble(reader["ValorMaximo"]);

                                result = new Regra(id_Regra,valorMinimo,valorMaximo);
                            }
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public void put(int key, Regra value)
        {
            string sql_cmd = "INSERT INTO Regra (idRegra, TempoMinimo, TempoMaximo, ValorMinimo, ValorMaximo) VALUES ('" +
                                value.getIdRegra() + "','" + value.getValorMinimo() + "','" + value.getValorMaximo()  + "');";
            try 
            {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Regra? remove(int key)
        {
            Regra? Regra = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Regra Where idRegra = {key}";
            try 
            {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Regra;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idRegra FROM Regra";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<int> aux = conn.Query<int>(sql_cmd);
                        foreach(int key in aux)
                        {
                            keys.Add(key);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return keys;
        }

        public ICollection<Regra> values()
        {
            ICollection<Regra> Regras = new HashSet<Regra>();
            string sql_cmd = "SELECT * FROM Regra";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Regra> aux = conn.Query<Regra>(sql_cmd);
                        foreach(Regra Regra in aux)
                        {
                            Regras.Add(Regra);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Regras;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Regra";
            try
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                size = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return size;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

        public bool constainsKey(int idRegra)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Regra Where idRegra = {idRegra}";
            try
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public bool containsValue(Regra value)
        {
            return this.constainsKey(value.getIdRegra());
        }
    }
}
