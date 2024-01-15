using Leilum.Data.DAOS;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.CategoriaLN;
using System.Data.SqlClient;
using Leilum.LeilumLN.LoteLN;
using Leilum.LeilumLN.ArtigoLN;

namespace Leilum.Data
{
    public class LeilumDLFacade : ILeilumDL
    {
        private ArtigoDAO artigoDAO;
        private CategoriaDAO categoriaDAO;
        private RegraDAO regraDAO;
        private UtilizadorDAO utilizadorDAO;
        private LeilaoDAO leilaoDao;
        private LoteDAO loteDao;
        private LicitacaoDAO licitacaoDao;

        public LeilumDLFacade()
        {
            this.artigoDAO = ArtigoDAO.getInstance();
            this.categoriaDAO = CategoriaDAO.getInstance();
            this.regraDAO = RegraDAO.getInstance();
            this.utilizadorDAO = UtilizadorDAO.getInstance();
            this.leilaoDao = LeilaoDAO.getInstance();
            this.loteDao = LoteDAO.getInstance();
            this.licitacaoDao = LicitacaoDAO.getInstance();
        }        
        
        // Utilizadores

        public bool existsEmail(string email)
        {   
            return this.utilizadorDAO.existsEmail(email);
        }

        public bool existsNIF(int nif)
        {
            return this.utilizadorDAO.existsNIF(nif);
        }

        public bool existsUtilizador(int nif)
        {
            return this.utilizadorDAO.containsNif(nif);
        }

        public bool existsUtilizador(Utilizador utilizador)
        {
            return this.utilizadorDAO.containsValue(utilizador);
        }

        public Utilizador getUtilizador(int nif)
        {
            return this.utilizadorDAO.getByNif(nif);
        }

         public Utilizador getUtilizadorWithEmail(string email)
        {
            return this.utilizadorDAO.getUtilizadorWithEmail(email);
        }

        public void addUtilizador(Utilizador utilizador)
        {
            this.utilizadorDAO.put(utilizador);
        }

        public void removeUtilizador(int nif)
        {
            this.utilizadorDAO.remove(nif);
        }

        public void removeUtilizador(string email)
        {
            this.utilizadorDAO.remove(this.utilizadorDAO.getUtilizadorWithEmail(email).getContribuinte());
        }

        public ICollection<Utilizador> getAllUtilizadores()
        {
            return this.utilizadorDAO.values();
        }

        
        //Verifica Utilizador 
        public bool verificaUtilizador(string email, string password) {
            Utilizador u = this.utilizadorDAO.getUtilizadorWithEmail(email);
            if (u != null) {
                if (u.getPassword() == password) return true;
            }
            return false;
        }
                
        // Regista Utilizador
        public void registaUtilizador(Utilizador u) {
            if (existsEmail(u.getEmail())) {
                Console.Write("Já existe um Utilizador com esse email!");
                return;
            }
            addUtilizador(u);
        }

        // Atualiza perfil utilizador
        public void atualizaPerfil(Utilizador u) {
            removeUtilizador(u.getEmail());
            addUtilizador(u);
        }

        // Atualiza tipo de utilizador (Admin)
        
        //Leilao
        
        public Leilao getLeilao(int idLeilao){
            return this.leilaoDao.get(idLeilao);
        }

        public ICollection<Leilao> getLeiloesEmCurso(){
            ICollection<Leilao> leiloesAtivos = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM db.Leilao WHERE Estado = 1";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime duracao = Convert.ToDateTime(reader["Duracao"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                int licitacaoAtual = Convert.ToInt32(reader["LicitacaoAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);

                                Licitacao licitacao = this.licitacaoDao.get(licitacaoAtual);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoria(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,duracao,valorAbertura,valorBase,valorMinimo,licitacao,estado,avaliador,comitente,lote,categoria);
                                leiloesAtivos.Add(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesAtivos;
        }

        public ICollection<Leilao> getLeiloesTerminados(){
            ICollection<Leilao> leiloesTerminados = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM db.Leilao WHERE Estado = 0";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime duracao = Convert.ToDateTime(reader["Duracao"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                int licitacaoAtual = Convert.ToInt32(reader["LicitacaoAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);

                                Licitacao licitacao = this.licitacaoDao.get(licitacaoAtual);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoria(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,duracao,valorAbertura,valorBase,valorMinimo,licitacao,estado,avaliador,comitente,lote,categoria);
                                leiloesTerminados.Add(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesTerminados;
        }

        // Get lista de leilões em curso e outro para leilões terminados
        // public ICollection<Leilao> getLeiloesEmCurso(){
        //     return this.leilaoDao.getLeiloesEmCurso();
        // }

        // public ICollection<Leilao> getLeiloesTerminaods(){
        //     return this.leilaoDao.getLeiloesTerminaods();
        // }
        
        // Cria Leilao inclui adicionar artigos e lotes! (Verificar se a classe do Lote tem uma lista de artigos)
        
        public void adicionaLeilao(Leilao leilao){
            this.leilaoDao.put(leilao.getNrLeilao(),leilao);
        }
        
        // Atualiza Leilao
        
        // Adiciona uma Licitação
        public void addLicitacao(Licitacao licitacao) {
            this.licitacaoDao.put(licitacao.getIdLicitacao(),licitacao);
        }

        // Remove uma Licitação
        public void removeLicitacao(int idLicitacao) {
            this.licitacaoDao.remove(idLicitacao);
        }
        
        // Get maior licitação de um leilão (Acho que não é preciso)
        
        // Get tempo restante de um leilao
        public DateTime TempoRestante(Leilao leilao)
        {
            TimeSpan diferenca = leilao.getDuracao() - DateTime.Now;
            DateTime tempoFuturo = DateTime.Now + diferenca;

            return tempoFuturo;
        }
                
        // Get categoria
        // public Categoria getCategoria(int idCategoria) {
        //     return this.categoriaDAO.get(idCategoria);
        // }

        public Categoria getCategoria(int CategoriaId){
            Categoria? result = null;
            string s_cmd = $"SELECT * FROM db.Categoria WHERE idCategoria = {CategoriaId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idCategoria = Convert.ToInt32(reader["idCategoria"]);
                                string? designacao = Convert.ToString(reader["Designacao"]);
                                int idRegra = Convert.ToInt32(reader["Regra"]);

                                Regra regra = this.regraDAO.get(idRegra);

                                result = new Categoria(idCategoria,designacao,regra);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return result;
        }
        
        // Adiciona Categoria
        public void addCategoria(Categoria categoria) {
            this.categoriaDAO.put(categoria.getIdCategoria(),categoria);
        }

        // Remove Categoria
        public void removeCategoria(int idCategoria) {
            this.categoriaDAO.remove(idCategoria);
        }
        
        // Get Regra
        public Regra getRegra(int idRegra) {
            return this.regraDAO.get(idRegra);
        }
        
        // Cria Regra (Admin)
        
        // Adiciona Regra (Admin)
        public void addRegra(Regra regra)
        {
            this.regraDAO.put(regra.getIdRegra(),regra);
        }
        
        // Remove Regra (Admin)
        public void removeRegra(int idRegra)
        {
            this.regraDAO.remove(idRegra);
        }

        // Lote

        public Lote getLote(int LoteId){

            Lote? lote = null;
            string s_cmd = $"SELECT * FROM db.Lote WHERE idLote = {LoteId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd, conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idLote = Convert.ToInt32(reader["idLote"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                string? compradorEmail = Convert.ToString(reader["Comprador"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? pathImg = Convert.ToString(reader["Imgpath"]);

                                lote = new Lote(idLote,comitenteEmail,compradorEmail,avaliadorEmail,pathImg,this.artigoDAO.getArtigosLote(LoteId));
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return lote;
        }
    }
}