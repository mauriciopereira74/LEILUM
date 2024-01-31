using Leilum.LeilumLN.UtilizadorLN;

namespace leilum.TransferData
{
    public class CurrentUser
    {
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
