using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.LoteLN;

namespace Leilum.Data.DAOS
{
    internal class LoteDAO
    {
        private static LoteDAO? singleton = null;

        public static LoteDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new LoteDAO();
            }
            return singleton;
        }

        public Lote? get(int idLote)
        {
            Lote? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Lote WHERE idLote = '{idLote}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Lote aux = con.QueryFirst<Lote>(sql_cmd);
                    result = aux;
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public void put(int key, Lote value)
        {
            string sql_cmd = "INSERT INTO Lote (idLote, Comitente, ImagPath) VALUES ('" +
                                value.getIdLote() + "','" + value.getComitente().getEmail() + "','" + value.getImagPath() + "');";
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

        public Lote? remove(int key)
        {
            Lote? Lote = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Lote Where idLote = {key}";
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
            return Lote;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idLote FROM Lote";
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

        public ICollection<Lote> values()
        {
            ICollection<Lote> lotes = new HashSet<Lote>();
            string sql_cmd = "SELECT * FROM Lote";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Lote> aux = conn.Query<Lote>(sql_cmd);
                        foreach(Lote lote in aux)
                        {
                            lotes.Add(lote);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lotes;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Lote";
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

        public bool constainsKey(int idLote)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Lote Where idLote = {idLote}";
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

        public bool containsValue(Lote value)
        {
            return this.constainsKey(value.getIdLote());
        }
    }
}
