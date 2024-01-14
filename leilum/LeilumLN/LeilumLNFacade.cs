
using Leilum.LeilumLN.Leilao;
using Leilum.LeilumLN.Utilizador;
using Leilum.Data;

namespace leilum.LeilumLN
{
    public class LeilumLNFacade : ILeilumLN
    {
        private ILeilumDL db; // base de dados

        public LeilumLNFacade()
        {
            this.db = new LeilumDLFacade();
        }

        public bool existsEmail(string email){
            return db.existsEmail(email);
        }

        public Utilizador getUtilizadorWithEmail(string email){
            return db.getUtilizadorWithEmail(email);
        }

        public bool validateNewAccount(string email){
            return !db.existsEmail(email);
        }

        public bool adicionaConta(Utilizador utilizador){
            if (this.validateNewAccount(utilizador.getEmail()))
            {
                this.db.addUtilizador(utilizador);
                return true;
            }
            return false;
        }
    }
}
