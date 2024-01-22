
using Leilum.LeilumLN.CategoriaLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.NotificacaoLN;
using Leilum.LeilumLN.UtilizadorLN;

namespace leilum.LeilumLN
{
    public interface ILeilumLN
    {
        public bool existsEmail(string email);

        public Utilizador getUtilizadorWithEmail(string email);

        public void updateUtilizador(Utilizador utilizador);

        public bool validateNewAccount(string email, int nif);

        public bool existsNIF(int nif);

        public bool adicionaConta(Utilizador utilizador);

        // Leiloes
        public IEnumerable<Leilao> getLeiloesEmCurso();
        public IEnumerable<Leilao> getLeiloesPendentesPorCategoria(int categoria);

        public Categoria getCategoriaAvaliador(string email);
        
        public bool addLicitacao(int idLeilao, string userEmail, double value);

        public int quantidadeArtigos();

        public int quantidadeLotes();
        
        public int quantidadeLeiloes();

        public Leilao getLeilao(int idLeilao);

        public List<Categoria> GetAllCategorias();

        public Categoria GetCategoriaByDesignacao(string s);
        public void addLeilao(Leilao l);

        public void adicionaLeilao(Leilao leilao);


        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador);

        public void adicionaNotificacao(Notificacao notificacao);

        public IEnumerable<Utilizador> getAllUtilizadores();

    }
}
