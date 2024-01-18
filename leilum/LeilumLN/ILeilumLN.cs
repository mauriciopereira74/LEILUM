
using Leilum.LeilumLN.LeilaoLN;
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
        public ICollection<Leilao> getLeiloesEmCurso();

        public bool addLicitacao(int idLeilao, string userEmail, double value);


        //public Leilao getLeilao(int nrLeilao);

    }
}
