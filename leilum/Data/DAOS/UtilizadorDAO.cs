using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.Utilizador;

namespace Leilum.Data.DAOS
{
    internal class UtilizadorDAO
    {
        private static UtilizadorDAO? singleton = null;

        public static UtilizadorDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new UtilizadorDAO();
            }
            return singleton;
        }

        public Utilizador getUtilizadorWithEmail(string email)
        {
            Utilizador? result = null;
            string s_cmd = $"SELECT * FROM dbo.Utilizador where Email = '{email}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    result = con.QueryFirst<Utilizador>(s_cmd);
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        public Utilizador getByNif(int nif)
        {
            Utilizador? utilizador = null;
            string s_cmd = $"SELECT * FROM dbo.Utilizador where contribuinte = '{nif}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Utilizador aux = con.QueryFirst<Utilizador>(s_cmd);
                    utilizador = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return utilizador;
        }

        public void put(int key, Utilizador value)
        {
        
            string sql_cmdUser = "INSERT INTO Utilizador (Email, Password, TipoUtilizador) VALUES ('" +
                                value.getEmail() + "','" + value.getPassword() + "','" + value.getTipoUtilizador() + "');";
            string sql_cmdInfoUser = "INSERT INTO InfoUtilizador (Contribuinte, Nome, Morada, Nacionalidade, Contacto, DataNascimento, MetodoPagamento, Iban, idUtilizador, FotoPerfilPath) VALUES ('" +
                                     value.getEmail() + "','" + value.getPassword() + "','" + value.getTipoUtilizador() + "','" + value.getFotoPerfil() + "');";
            try 
            {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmdUser, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(sql_cmdInfoUser, con))
                    {
                        con.Open();
                        cmd2.ExecuteNonQuery();
                    }
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Utilizador? remove(int nif)
        {
            Utilizador? Utilizador = getByNif(nif);
            string sql_cmd = $"DELETE FROM Utilizador Where Email = {Utilizador.getEmail()}";
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
            return Utilizador;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT Email FROM Utilizador";
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

        public ICollection<Utilizador> values()
        {
            ICollection<Utilizador> Utilizadors = new HashSet<Utilizador>();
            string sql_cmd = "SELECT * FROM Utilizador";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Utilizador> aux = conn.Query<Utilizador>(sql_cmd);
                        foreach(Utilizador Utilizador in aux)
                        {
                            Utilizadors.Add(Utilizador);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Utilizadors;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Utilizador";
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

        public bool existsEmail(string email)
        {
            bool result = false;
            string s_cmd = $"SELECT * FROM dbo.Utilizador where Email = '{email}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Utilizador> aux = con.Query<Utilizador>(s_cmd);
                    result = aux.Count() == 1;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        public bool containsNif(int nif)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Utilizador WHERE contribuinte = " + nif;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no containsKey do UtilizadorDAO");
            }
            return result;
        }

        public bool containsValue(Utilizador value)
        {
            return containsNif(value.getContribuinte());
        }

        public bool existsNIF(int nif)
        {
            bool result = false;
            string s_cmd = $"SELECT * FROM dbo.Utilizador where nif = '{nif}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Utilizador> aux = con.Query<Utilizador>(s_cmd);
                    result = aux.Count() == 1;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }
    }
}
