using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.UtilizadorLN;

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
            if (email == "") return null;

            Utilizador result = null;
            string s_cmd = $" SELECT U.Email, U.Password, U.TipoUtilizador, I.Contribuinte, I.Nome, I.Morada, I.Nacionalidade, I.DataNascimento, I.Contacto, I.MetodoPagamento, I.Iban, I.FotoPerfilPath, I.idUtilizador FROM dbo.Utilizador U LEFT JOIN dbo.InfoUtilizador I ON U.Email = I.idUtilizador WHERE U.Email = '{email}'";
            
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    // Execute the query and retrieve the result
                    var utilizadorInfo = con.QueryFirstOrDefault(s_cmd);

                    // Check if a record with the specified Email exists
                    if (utilizadorInfo != null)
                    {
                        // Manually create a Utilizador object using the retrieved values
                        result = new Utilizador();
                        result.setEmail(utilizadorInfo.Email);
                        result.setTipoUtilizador(utilizadorInfo.TipoUtilizador);
                        result.setPassword(utilizadorInfo.Password);
                        result.setContribuinte(utilizadorInfo.Contribuinte);
                        result.setNome(utilizadorInfo.Nome);
                        result.setMorada(utilizadorInfo.Morada);
                        result.setNacionalidade(utilizadorInfo.Nacionalidade);
                        result.SetDataNascimento(utilizadorInfo.DataNascimento);
                        result.setContacto(utilizadorInfo.Contacto);
                        result.setMetodoPagamento(utilizadorInfo.MetodoPagamento);
                        result.setIban(utilizadorInfo.Iban);
                        result.setFotoPerfil(utilizadorInfo.FotoPerfilPath);
                    }
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

        public void put(Utilizador value)
        {
        
            string sql_cmdUser = "INSERT INTO Utilizador (Email, Password, TipoUtilizador) VALUES ('" +
                                value.getEmail() + "','" + value.getPassword() + "','" + value.getTipoUtilizador()  +  "');";
            string sql_cmdInfoUser = "INSERT INTO InfoUtilizador (Contribuinte, Nome, Morada, Nacionalidade, Contacto, DataNascimento, MetodoPagamento, Iban, FotoPerfilPath, idUtilizador) VALUES ('" +
                                     value.getContribuinte() + "','" + value.getNome() + "','" + value.getMorada() + "','" + value.getNacionalidade()+ "','" + value.getContacto() + "','" + value.getDataNascimentoSTR() + "','" + value.getMetodoPagamento() + "','" + value.getIban() + "','" +  value.getFotoPerfil() + "','" + value.getEmail() + "');";
            try 
            {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand(sql_cmdUser, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(sql_cmdInfoUser, con))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void update(Utilizador value)
        {
            string sql_cmdUser = "UPDATE Utilizador SET " +
                                $"Password = '{value.getPassword()}', " +
                                $"TipoUtilizador = '{value.getTipoUtilizador()}' " +
                                $"WHERE Email = '{value.getEmail()}';";

            string sql_cmdInfoUser = "UPDATE InfoUtilizador SET " +
                                    $"Contribuinte = '{value.getContribuinte()}', " +
                                    $"Nome = '{value.getNome()}', " +
                                    $"Morada = '{value.getMorada()}', " +
                                    $"Nacionalidade = '{value.getNacionalidade()}', " +
                                    $"Contacto = '{value.getContacto()}', " +
                                    $"DataNascimento = '{value.getDataNascimentoSTR()}', " +
                                    $"MetodoPagamento = '{value.getMetodoPagamento()}', " +
                                    $"Iban = '{value.getIban()}', " +
                                    $"FotoPerfilPath = '{value.getFotoPerfil()}' " +
                                    $"WHERE idUtilizador = '{value.getEmail()}';";

            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmdUser, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(sql_cmdInfoUser, con))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
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

        public void updateParaAvaliador(string key){
            string sql_cmd = $"UPDATE Utilizador SET TipoUtilizador = {configGerais.Avaliador} WHERE Email = {key}";
            try{
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using(SqlCommand cmd = new SqlCommand(sql_cmd, conn)){
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
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

        public IEnumerable<Utilizador> values()
        {
            IEnumerable<Utilizador> Utilizadors = new HashSet<Utilizador>();
            string sql_cmd = "SELECT * FROM Utilizador";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                string? email = Convert.ToString(reader["Email"]);
                                string? password = Convert.ToString(reader["Password"]);
                                int TipoUtilizador = Convert.ToInt32(reader["TipoUtilizador"]);

                                Utilizador utilizador = new Utilizador(email,password,TipoUtilizador);
                                Utilizadors = Utilizadors.Append(utilizador);
                            }
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

        public IEnumerable<Utilizador> getAllClientes(int tipo)
        {
            IEnumerable<Utilizador> Utilizadors = new HashSet<Utilizador>();
            string sql_cmd = $"SELECT * FROM Utilizador WHERE TipoUtilizador = {tipo}";
            
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                string? email = Convert.ToString(reader["Email"]);
                                string? password = Convert.ToString(reader["Password"]);
                                int TipoUtilizador = Convert.ToInt32(reader["TipoUtilizador"]);

                                Utilizador utilizador = new Utilizador(email,password,TipoUtilizador);
                                Utilizadors = Utilizadors.Append(utilizador);
                            }
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
            string s_cmd = "SELECT * FROM dbo.InfoUtilizador WHERE contribuinte = " + nif;
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
            string s_cmd = $"SELECT Contribuinte, Nome, Morada, Nacionalidade, Contacto, DataNascimento, MetodoPagamento, Iban, FotoPerfilPath, idUtilizador FROM dbo.InfoUtilizador WHERE Contribuinte = '{nif}'";
            
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();

                    // Execute the query and retrieve the result
                    var infoUtilizador = con.QueryFirstOrDefault(s_cmd);

                    // Check if a record with the specified Contribuinte exists
                    if (infoUtilizador != null)
                    {
                        // Manually create a Utilizador object using the retrieved values
                        Utilizador u = new Utilizador();
                        u.setEmail(infoUtilizador.idUtilizador);
                        u.setTipoUtilizador(infoUtilizador.idUtilizador);
                        u.setContribuinte(infoUtilizador.Contribuinte);
                        u.setNome(infoUtilizador.Nome);
                        u.setMorada(infoUtilizador.Morada);
                        u.setNacionalidade(infoUtilizador.Nacionalidade);
                        u.SetDataNascimento(infoUtilizador.DataNascimento);
                        u.setContacto(infoUtilizador.Contacto);
                        u.setMetodoPagamento(infoUtilizador.MetodoPagamento);
                        u.setIban(infoUtilizador.Iban);
                        u.setFotoPerfil(infoUtilizador.FotoPerfilPath);

                        result = true; // A record with the specified Contribuinte exists
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }

            return result;
        }

        public static Utilizador getAvaliador(string avaliadorEmail){
            
            Utilizador? resultado = null;
            string s_cmd = $"SELECT * FROM db.Utilizador WHERE Email = {avaliadorEmail}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();
                    Utilizador a = conn.QueryFirst<Utilizador>(s_cmd);
                    resultado = a;
                }
            } catch (Exception e){
                throw new DAOException(e.Message);
            }
            return resultado;
        }

        public static Utilizador getComitente(string comitenteEmail){

            Utilizador? resultado = null;
            string s_cmd = $"SELECT * FROM db.Utilizador WHERE Email = {comitenteEmail}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();
                    Utilizador c = conn.QueryFirst<Utilizador>(s_cmd);
                    resultado = c;
                }
            } catch (Exception e){
                throw new DAOException(e.Message);
            }
            return resultado;
        }
    }
}
