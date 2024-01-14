using Dapper;
using System.Data.SqlClient;
using Leilum.LeilumLN.Leilao;
using Leilum.Data.DAOS.UtilizadorDAO;
using Leilum.Data.DAOS.LoteDAO;
using Leilum.Data.DAOS.CategoriaDAO;
using Leilum.Data.DAOS.ArtigoDAO;

namespace Leilum.Data.DAOS
{
    internal class LeilaoDAO
    {
        private static LeilaoDAO? singleton = null;

        public static LeilaoDAO getInstance()
        {
            if(singleton == null)
            {
                singleton = new LeilaoDAO();
            }
            return singleton;
        }

        public static Leilao? get(int idLeilao)
        {
            Leilao? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Leilao WHERE idLeilao = '{idLeilao}'";
            try
            {
                using (SqlConnection con = new(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Leilao aux = con.QueryFirst<Leilao>(sql_cmd);
                    result = aux;
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public void put(int key, Leilao value)
        {
            string sql_cmd = "INSERT INTO Leilao (idLeilao, Titulo, Duracao, ValorAbertura, ValorBase, ValorMinimo, Estado, Avaliador, Comitente, Lote, Categoria) VALUES ('" +
                                value.getNrLeilao() + "','" + value.getTitutlo() + "','" + value.getDuracao() + "','" +
                                value.getValorAbertura() + "','" + value.getValorBase() + "','" + value.getValorMinimo() + "','" + value.getEstado() + "','" + value.getAvaliador() + "','" + value.getIdComitente() + "','" + value.getIdLote() + "','" + value.getCategoriaId() + "');";
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

        public Leilao? remove(int key)
        {
            Leilao? leilao = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Leilao Where idLeilao = {key}";
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
            return leilao;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new HashSet<int>();
            string sql_cmd = "SELECT idLeilao FROM Leilao";
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

        public ICollection<Leilao> values()
        {
            ICollection<Leilao> leiloes = new HashSet<Leilao>();
            string sql_cmd = "SELECT * FROM Leilao";
            try 
            {
                using(SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using(SqlCommand cmd = new SqlCommand(sql_cmd,conn))
                    {
                        conn.Open();
                        IEnumerable<Leilao> aux = conn.Query<Leilao>(sql_cmd);
                        foreach(Leilao leilao in aux)
                        {
                            leiloes.Add(leilao);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return leiloes;
        }

        public int size()
        {
            int size = 0;
            string sql_cmd = "SELECT COUNT(*) FROM Leilao";
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

        public bool constainsKey(int idLeilao)
        {
            bool result = false;
            string sql_cmd = $"SELECT * FROM Leilao Where idLeilao = {idLeilao}";
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

        public bool containsValue(Leilao value)
        {
            return this.constainsKey(value.getNrLeilao());
        }

        public ICollection<Leilao> getLeiloesEmCurso(){
            ICollection<Leilao> leiloesAtivos = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM db.Leilao WHERE Estado = 1";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();
                    IEnumerable<dynamic> leiloes = conn.Query<dynamic>(s_cmd);
                    foreach (var leilaoAux in leiloes){

                        DateTime duracao = leilaoAux.duracao as DateTime?;

                        Licitacao licitacao = getLicitacao(leilaoAux.licitacao);

                        Utilizador avaliador = getAvaliador(leilaoAux.avaliador);

                        Utilizador comitente = getComitente(leilaoAux.comitente);

                        Lote lote = getLote(leilaoAux.lote);

                        Categoria categoria = getCategoria(leilaoAux.categoria);

                        Leilao leilao = new Leilao((int)leilaoAux.nrLeilao,(string)leilaoAux.titulo,duracao,(double)leilaoAux.valorAbertura,(double)leilaoAux.valorBase,(double)leilaoAux.valorMinimo
                                                  ,licitacao,(int)leilaoAux.estado,avaliador,comitente,lote,categoria);

                        leiloesAtivos.Add(leilao);
                    }
                }
            }
        }

        public ICollection<Leilao> getLeiloesTerminados(){
            ICollection<Leilao> leiloesTerminados = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM db.Leilao WHERE Estado = 0";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();
                    IEnumerable<Leilao> leiloes = conn.Query<Leilao>(s_cmd);
                    foreach (Leilao leilao in leiloes){

                        Utilizador avaliador = getAvaliador(leilao.getAvaliador());

                        Utilizador comitente = getComitente(leilao.getComitente());

                        Lote lote = getLote(leilao.getLote());

                        Categoria categoria = getCategoria(leilao.getCategoria());

                        leilao.setAvaliador(avaliador);
                        leilao.setComitente(comitente);
                        leilao.setLote(lote);
                        leilao.setCategoria(categoria);
                        leiloesAtivos.Add(leilao);
                    }
                }
            }
        }
    }
}
