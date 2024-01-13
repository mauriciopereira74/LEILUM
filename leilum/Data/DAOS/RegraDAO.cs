using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.Categoria;

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

        public static Regra? get(int idRegra)
        {
            Regra? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Regra WHERE idRegra = '{idRegra}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Regra aux = con.QueryFirst<Regra>(sql_cmd);
                    result = aux;
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
            string sql_cmd = "INSERT INTO LEILUM.Regra (idRegra, TempoMinimo, TempoMaximo, ValorMinimo, ValorMaximo) VALUES ('" +
                                value.getIdRegra() + "','" + value.getTempoMinimo() + "','" + value.getTempoMaximo() + "','" + value.getValorMinimo() + "','" + value.getValorMaximo()  + "');";
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
            string sql_cmd = "SELECT idRegra FROM LEILUM.Regra";
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
            string sql_cmd = "SELECT * FROM LEILUM.Regra";
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
            string sql_cmd = "SELECT COUNT(*) FROM LEILUM.Regra";
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
