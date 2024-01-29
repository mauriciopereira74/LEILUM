
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
        public IEnumerable<Leilao> getLeiloesTerminados();
        public IEnumerable<Leilao> getLeiloesPendentes();
        public IEnumerable<Leilao> getLeiloesPendentesPorCategoria(int categoria, string avaliador);
        public IEnumerable<Leilao> getLeiloesParticipados(string email);
        public IEnumerable<Leilao> getLeiloesCriados(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesGanhos(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesRecomendados(string utilizadorEmail);
        public double getGastosTotaisUtilizador(string utilizadorEmail);

        public Categoria getCategoriaAvaliador(string email);

        public void startAuction(int auctionId, int bvalue, int mvalue, int ovalue, string evaluator);

        public void rejectAuction(int auctionId, string evaluator);
        
        public bool addLicitacao(int idLeilao, string userEmail, double value);

        public Utilizador getVencedor(int idLeilao);

        public int quantidadeArtigos();

        public int quantidadeLotes();
        
        public int quantidadeLeiloes();

        public Leilao getLeilao(int idLeilao);

        public void UpdateDataFinal(int idLeilao, string newDataFinal);

        public List<Categoria> GetAllCategorias();

        public Categoria GetCategoriaByDesignacao(string s);
        public void addLeilao(Leilao l);

        public void adicionaLeilao(Leilao leilao);

        public void terminaLeilao(int idLeilao);
        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador);

        public void adicionaNotificacao(Notificacao notificacao);

        public IEnumerable<Utilizador> getAllUtilizadores();

        public void promoteUtilizador(Utilizador u, string categoria);
        public IEnumerable<Utilizador> getAllClientes();

        public Dictionary<string, int> CalcularGastosPorMes(int ano);
        public List<int> ObterAnosComLeiloes(IEnumerable<Leilao> leiloes);

        public int getIdMetodoPagamento(string designacao);
        public string getDesignacaoMetodoPagamento(int metodo);
        public ICollection<string> getAllMetodoPagamentos();
    }
}
