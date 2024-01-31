using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.LeilaoLN;

namespace Leilum.Data.DAOS
{
    internal class LicitacaoDAO
    {
        private static LicitacaoDAO? singleton = null;

        public static LicitacaoDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new LicitacaoDAO();
            }
            return singleton;
        }

        public Licitacao? get(int idLicitacao)
        {
            Licitacao? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Licitacao WHERE idLicitacao = '{idLicitacao}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Licitacao aux = con.QueryFirst<Licitacao>(sql_cmd);
                    result = aux;
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public void put(int key, Licitacao value)
        {
            string sql_cmd = $"INSERT INTO Licitacao (idLicitacao, Valor, Licitador, Leilao) VALUES ('" +
                                key + "','" + value.getValor() + "','" + value.getIdLicitador() + "','" +
                                value.getIdLeilao() + "');";
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

        public Licitacao? remove(int key)
        {
            Licitacao? Licitacao = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Licitacao Where idLicitacao = {key}";
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
            return Licitacao;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idLicitacao FROM Licitacao";
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

        public ICollection<Licitacao> values()
        {
            ICollection<Licitacao> licitacaos = new HashSet<Licitacao>();
            string sql_cmd = "SELECT * FROM Licitacao";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Licitacao> aux = conn.Query<Licitacao>(sql_cmd);
                        foreach(Licitacao Licitacao in aux)
                        {
                            licitacaos.Add(Licitacao);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return licitacaos;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Licitacao";
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

        public bool constainsKey(int idLicitacao)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Licitacao Where idLicitacao = {idLicitacao}";
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

        public bool containsValue(Licitacao value)
        {
            return this.constainsKey(value.getIdLicitacao());
        }

    }
}
