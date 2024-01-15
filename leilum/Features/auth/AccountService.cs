using System.ComponentModel.DataAnnotations;
using Leilum.LeilumLN.UtilizadorLN;

namespace leilum.Features.auth
{
    public class AccountService
    {
        private List<Utilizador> _users;

        public AccountService()
        {
            _users = new List<Utilizador>
            {
                new Utilizador ("admin@admin.com", "admin" , 0),
                new Utilizador ("user@user.com", "user" , 1),
            };
        }

        public Utilizador? GetByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.getEmail() == email);
        }
    }
}