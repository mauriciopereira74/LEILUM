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

        public static Utilizador? get(int Email)
        {
            Utilizador? result = null;
            string sql_cmd = "SELECT * FROM Utilizador" + 
                             "INNER JOIN InfoUtilizador ON UTILIZADOR.Email = InfoUtilizador.idUtilizador" + 
                             $"Where Utilizador.Email = '{Email}';";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string? email = Convert.ToString(reader["Email"]);
                                string? password = Convert.ToString(reader["Password"]);
                                int tipoUtilizador = Convert.ToInt32(reader["idUtilizador"]);
                                int contribuinte = Convert.ToInt32(reader["Contribuinte"]);
                                string? nome = Convert.ToString(reader["Nome"]);
                                string? morada = Convert.ToString(reader["Morada"]);
                                string? nacionalidade = Convert.ToString(reader["Nacionalidade"]);
                                string? contacto = Convert.ToString(reader["Contacto"]);
                                DateTime aux = Convert.ToDateTime(reader["DataNascimento"]);
                                DateOnly dataNascimento = new DateOnly(aux.Year, aux.Month, aux.Day);
                                int metodoPagamento = Convert.ToInt32(reader["MetodoPagamento"]);
                                string? iban = Convert.ToString(reader["Iban"]);
                                string imgPath = Convert.ToString(reader["FotoPerfilPath"]);
                                result = new Utilizador(email, password, tipoUtilizador, imgPath, contribuinte, nome, morada,
                                    nacionalidade, contacto, dataNascimento, metodoPagamento, iban);
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

        public void put(string key, Utilizador value)
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

        public Utilizador? remove(int key)
        {
            Utilizador? Utilizador = get(key);
            string sql_cmd = $"DELETE FROM Utilizador Where Email = {key}";
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

        public bool constainsKey(string emailUtilizador)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Utilizador Where Email = {emailUtilizador}";
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

        public bool containsValue(Utilizador value)
        {
            return this.constainsKey(value.getEmail());
        }
    }
}
