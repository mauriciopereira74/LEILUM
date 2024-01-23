using Leilum.LeilumLN.ArtigoLN;
using Dapper;
using System.Data.SqlClient;

namespace Leilum.Data.DAOS
{
    internal class ArtigoDAO
    {
        private static ArtigoDAO? singleton = null;

        public static ArtigoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new ArtigoDAO();
            }

            return singleton;
        }

        public static Artigo? get(int idArtigo)
        {
            Artigo? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Artigo WHERE idArtigo = '{idArtigo}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Artigo aux = con.QueryFirst<Artigo>(sql_cmd);
                    result = aux;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public void put(int key, Artigo value)
        {
            string sql_cmd = "INSERT INTO Artigo (idArtigo, Designacao, Caracteristicas, Descricao, idLote, ImagPath) VALUES ('" +
                             key + "','" + value.getDesignacao() + "','" + value.getCaracteristicas() + "','" +
                             value.getDescricao() + "','" + value.getLoteId() + "','" + value.getImagPath() + "');";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
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
        }

        public Artigo? remove(int key)
        {
            Artigo? artigo = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Artigo Where idArtigo = {key}";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
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

            return artigo;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idArtigo FROM Artigo";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn))
                    {
                        conn.Open();
                        IEnumerable<int> aux = conn.Query<int>(sql_cmd);
                        foreach (int key in aux)
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

        public ICollection<Artigo> values()
        {
            ICollection<Artigo> artigos = new HashSet<Artigo>();
            string sql_cmd = "SELECT * FROM Artigo";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn))
                    {
                        conn.Open();
                        IEnumerable<Artigo> aux = conn.Query<Artigo>(sql_cmd);
                        foreach (Artigo artigo in aux)
                        {
                            artigos.Add(artigo);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return artigos;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Artigo";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
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

        public bool constainsKey(int idArtigo)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Artigo Where idArtigo = {idArtigo}";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn))
                    {
                        conn.Open();
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public bool containsValue(Artigo value)
        {
            return this.constainsKey(value.getId_Artigo());
        }

        public List<Artigo> getArtigosLote(int LoteId){
            List<Artigo> artigos = new List<Artigo>();
            string s_cmd = $"SELECT * FROM Artigo WHERE idLote = {LoteId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd, conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int idArtigo = Convert.ToInt32(reader["idArtigo"]);
                                string? designacao = Convert.ToString(reader["Designacao"]);
                                string? caracteristicas = Convert.ToString(reader["Caracteristicas"]);
                                string? descricao = Convert.ToString(reader["Descricao"]);
                                int idLote = Convert.ToInt32(reader["idLote"]);
                                string imagPath = Convert.ToString(reader["ImagPath"]);
                                Artigo artigo = new Artigo(idArtigo,designacao,caracteristicas,descricao,idLote, imagPath);
                                artigos.Add(artigo);

                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return artigos;
        }
    }
}
    
