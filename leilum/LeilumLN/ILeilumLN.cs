
using Leilum.LeilumLN.Leilao;
using Leilum.LeilumLN.Utilizador;

namespace leilum.LeilumLN
{
    public interface ILeilumLN
    {
        public bool existsEmail(string email);

        public Utilizador getUtilizadorWithEmail(string email);

        public bool validateNewAccount(string email);

        public bool adicionaConta(Utilizador utilizador);

        // Leiloes
        //public ICollection<Leilao> getLeiloesEmCurso();

        //public Leilao getLeilao(int nrLeilao);
    
    }
}
