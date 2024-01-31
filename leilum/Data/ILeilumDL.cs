using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.CategoriaLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.NotificacaoLN;
using Leilum.LeilumLN.UtilizadorLN;

namespace Leilum.Data
{
    public interface ILeilumDL
    {
        public bool existsUtilizador(int nif);

        public bool existsUtilizador(Utilizador utilizador);

        public Utilizador getUtilizador(int nif);

        public void addUtilizador(Utilizador utilizador);

        public void removeUtilizador(int nif);

        public IEnumerable<Utilizador> getAllUtilizadores();

        public IEnumerable<Utilizador> getAllClientes();

        public void updateUtilizador(Utilizador utilizador);

        public bool existsEmail(string email);
        public bool existsNIF(int nif);
        public Utilizador getUtilizadorWithEmail(string email);
        public bool verificaUtilizador(string email, string password);
        public void registaUtilizador(Utilizador u);
        public void atualizaPerfil(Utilizador u);
        public Leilao getLeilao(int idLeilao);
        public void addLeilao(Leilao leilao);

        public void UpdateDataFinal(int idLeilao, string newDataFinal);
        public int quantidadeLeiloes();
        public bool addLicitacao(Licitacao licitacao);
        public double? getMaiorLicitacao(int idLeilao);
        public Utilizador getVencedor(int idLeilao);
        public bool addLicitacao(double value, int idLeilao, string emailUser);
        public void removeLicitacao(int idLicitacao);
        public Categoria getCategoriaById(int idCategoria);

        public Categoria getCategoriaByDesignacao(string Designacao);
        public List<Categoria> GetAllCategorias();
        public void addCategoria(Categoria categoria);
        public void removeCategoria(int idCategoria);
        public int getIdCategoria(string designacao);
        public ICollection<string> getCategoriasList();
        public IEnumerable<Leilao> getLeiloesPendentes(int _categoria, string avaliador);
        public Regra getRegra(int idRegra);
        public void addRegra(Regra regra);
        public void removeRegra(int idRegra);
        public void adicionaArtigo(Artigo artigo);
        public int quantidadeArtigos();
        public int quantidadeLotes();
        public ICollection<Leilao> getLeiloesComitentes(string uComitente);
        public IEnumerable<Leilao> getLeiloesEmCurso();
        public IEnumerable<Leilao> getLeiloesParticipados(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesCriados(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesGanhos(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesRecomendados(string utilizadorEmail);
        public double getGastosTotaisUtilizador(string utilizadorEmail);
        public IEnumerable<Leilao> getLeiloesTerminados();
        public IEnumerable<Leilao> getLeiloesPendentes();
        public Categoria? getCategoriaAvaliador(string email);
        public void adcionaLeilao(Leilao l);
        public void atualizaValorBaseLeilaoEstado(int idLeilao, int valorBase, int valorMinimo, int valorAbertura,
            string avaliador);
        
        public void terminaLeilao(int idLeilao);

        public void rejeitaLeilao(int idLeilao, string avaliador);
        
        public void setCategoriaAvaliador(string email, int categoria);
        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador);
        public void adicionaNotificacao(Notificacao notificacao);

        public int getIdMetodoPagamentoByDesignacao(string designacao);
        public string getDesignacaoMetodoPagamento(int metodo);
        public ICollection<string> getListMetodoPagamento();
    }
}