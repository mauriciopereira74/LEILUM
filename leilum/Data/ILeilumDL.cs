using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.CategoriaLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.UtilizadorLN;

namespace Leilum.Data
{
    public interface ILeilumDL
    {
        // TODO Implementar metodos aqui;
        // Utilizadores
        public bool existsUtilizador(int nif);

        public bool existsUtilizador(Utilizador utilizador);

        public Utilizador getUtilizador(int nif);

        public void addUtilizador(Utilizador utilizador);

        public void removeUtilizador(int nif);

        public IEnumerable<Utilizador> getAllUtilizadores();

        public void updateUtilizador(Utilizador utilizador);

        public bool existsEmail(string email);
        public bool existsNIF(int nif);
        public Utilizador getUtilizadorWithEmail(string email);
        public bool verificaUtilizador(string email, string password);
        public void registaUtilizador(Utilizador u);
        public void atualizaPerfil(Utilizador u);
        public Leilao getLeilao(int idLeilao);
        public void addLeilao(Leilao leilao);
        public int quantidadeLeiloes();
        public bool addLicitacao(Licitacao licitacao);
        public double? getMaiorLicitacao(int idLeilao);
        public bool addLicitacao(double value, int idLeilao, string emailUser);
        public void removeLicitacao(int idLicitacao);
        public Categoria getCategoriaById(int idCategoria);

        public Categoria getCategoriaByDesignacao(string Designacao);
        public List<Categoria> GetAllCategorias();
        public void addCategoria(Categoria categoria);
        public void removeCategoria(int idCategoria);
        public int getIdCategoria(string designacao);
        public ICollection<string> getCategoriasList();
        public IEnumerable<Leilao> getLeiloesPendentes(int _categoria);
        public Regra getRegra(int idRegra);
        public void addRegra(Regra regra);
        public void removeRegra(int idRegra);
        public void adicionaArtigo(Artigo artigo);
        public int quantidadeArtigos();
        public int quantidadeLotes();
        public ICollection<Leilao> getLeiloesComitentes(string uComitente);
        public IEnumerable<Leilao> getLeiloesEmCurso();
        public Categoria? getCategoriaAvaliador(string email);
        public void adcionaLeilao(Leilao l);

        public void atualizaValorBaseLeilaoEstado(int idLeilao, int valorBase, int valorMinimo, int valorAbertura,
            string avaliador);

    }
}