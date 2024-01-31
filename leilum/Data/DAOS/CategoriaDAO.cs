
using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.CategoriaLN;

namespace Leilum.Data.DAOS
{
    internal class CategoriaDAO
    {
        private static CategoriaDAO? singleton = null;

        public static CategoriaDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new CategoriaDAO();
            }
            return singleton;
        }

        public Categoria get(int categoriaId){
            
            Categoria? resultado = null;
            string s_cmd = $"SELECT * FROM db.Categoria WHERE idCategoria = {categoriaId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();

                    var categoria=0;
                    var designacao = "";
                    var regra = 0;

                    dynamic row = conn.Query(s_cmd).FirstOrDefault();

                    if (row != null){
                        categoria = row.idCategoria;
                        designacao = row.Designacao;
                        regra = row.Regra;
                    }
                    string s_cmd2 = $"SELECT * FROM db.Regra WHERE idRegra = {regra}";
                    Regra r = conn.QueryFirst<Regra>(s_cmd2);

                    resultado = new Categoria(categoriaId,designacao,r);
                }
            } catch (Exception e){
                throw new DAOException(e.Message);
            }
            return resultado;
        }
        

        public void put(int key, Categoria value)
        {
            string sql_cmd = "INSERT INTO Categoria (idCategoria, Designacao, Regra) VALUES ('" +
                                value.getIdCategoria() + "','" + value.getDesignacao() + "','" + value.getRegra() +"');";
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

        public Categoria? remove(int key)
        {
            Categoria? Categoria = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Categoria Where idCategoria = {key}";
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
            return Categoria;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idCategoria FROM Categoria";
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

        public ICollection<Categoria> values()
        {
            ICollection<Categoria> Categorias = new HashSet<Categoria>();
            string sql_cmd = "SELECT * FROM Categoria";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Categoria> aux = conn.Query<Categoria>(sql_cmd);
                        foreach(Categoria Categoria in aux)
                        {
                            Categorias.Add(Categoria);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Categorias;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Categoria";
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

        public bool constainsKey(int idCategoria)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Categoria Where idCategoria = {idCategoria}";
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

        public bool containsValue(Categoria value)
        {
            return this.constainsKey(value.getIdCategoria());
        }
    }
}

