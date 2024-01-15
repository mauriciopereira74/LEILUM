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

        public bool existsEmail(string email);
        public bool existsNIF(int nif);
        public Utilizador getUtilizadorWithEmail(string email);
    }
}