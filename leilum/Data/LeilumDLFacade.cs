using Leilum.Data.DAOS;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.CategoriaLN;

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
            this.utilizadorDAO.put(utilizador.getContribuinte(), utilizador);
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
        /*
        public Leilao getLeilao(int idLeilao){
            return this.leilaoDao.get(idLeilao);
        }

        // Get lista de leilões em curso e outro para leilões terminados
        public ICollection<Leilao> getLeiloesEmCurso(){
            return this.leilaoDao.getLeiloesEmCurso();
        }

        public ICollection<Leilao> getLeiloesTerminaods(){
            return this.leilaoDao.getLeiloesTerminaods();
        }
        
        // Cria Leilao inclui adicionar artigos e lotes! (Verificar se a classe do Lote tem uma lista de artigos)
        
        public void adicionaLeilao(Leilao leilao){
            this.leilaoDao.adicionaLeilao(leilao);
        }
        */
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
        
        // Categoria
        
        // Get categoria
        public Categoria getCategoria(int idCategoria) {
            return this.categoriaDAO.get(idCategoria);
        }

        


        
        // Cria Categoria
        
        // Regras
        
        // Get Regra
        
        // Cria Regra (Admin)
    }
}