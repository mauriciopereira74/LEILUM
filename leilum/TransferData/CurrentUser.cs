using Leilum.LeilumLN.UtilizadorLN;

namespace leilum.TransferData
{
    public class CurrentUser
    {
        /*Esta é uma classe de uma única instância cujo objectivo é armazenar o utilizadot com sessão iniciada*/
        private static Utilizador? current = null;
        private CurrentUser() { }

        public static void setCurrentUser(Utilizador user)
        {
            CurrentUser.current = user;
        }

        public static Utilizador getCurrentUser()
        {
            return CurrentUser.current;
        }
    }
}
