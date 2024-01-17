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

        public ICollection<Utilizador> getAllUtilizadores();

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
        public void addLicitacao(Licitacao licitacao);
        public void removeLicitacao(int idLicitacao);
        public Categoria getCategoria(int idCategoria);
        public void addCategoria(Categoria categoria);
        public void removeCategoria(int idCategoria);
        public Regra getRegra(int idRegra);
        public void addRegra(Regra regra);
        public void removeRegra(int idRegra);
        public void adicionaArtigo(Artigo artigo);
        public int quantidadeArtigos();
        public int quantidadeLotes();
        public ICollection<Leilao> getLeiloesComitentes(string uComitente);
        public ICollection<Leilao> getLeiloesEmCurso();
    }
}