using Leilum.Data.DAOS;
using Leilum.LeilumLN.Utilizador;

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

        
        //Verifica Email
        
        //Verifica Password
        
        // Get Utilizador
        
        // Regista Utilizador
        
        // Atualiza perfil utilizador
        
        // Atualiza tipo de utilizador (Admin)
        
        //Leilao
        
        // Get Leilao
        
        // Get lista de leilões em curso e outro para leilões terminados
        
        // Cria Leilao inclui adicionar artigos e lotes! (Verificar se a classe do Lote tem uma lista de artigos)
        
        // Atualiza Leilao
        
        // Realiza Licitação
        
        // Get maior licitação de um leilão
        
        // Get tempo Restante
        
        // Categoria
        
        // Get categoria
        
        // Cria Categoria
        
        // Regras
        
        // Get Regra
        
        // Cria Regra (Admin)
    }
}