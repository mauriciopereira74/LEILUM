

namespace Leilum.LeilumLN.Utilizador
{

    public class Utilizador{

        private string email { get; set; }
        private string password { get; set; }
        private int idTipoUtilizador { get; set; }
        private int contribuinte { get; set; }
        private string nome { get; set; }
        private string morada { get; set; }
        private string nacionalidade { get; set; }
        private string contacto { get; set; }
        private DateOnly dataNascimento { get; set; }
        private int metodoPagamento { get; set; }
        private string iban { get; set; }
        
        public Utilizador(string email, string password, int idTipoUtilizador, int contribuinte, string nome, string morada, string nacionalidade, string contacto, DateOnly dataNascimento, int metodoPagamento, string iban){
            this.email = email;
            this.password = password;
            this.idTipoUtilizador = idTipoUtilizador;
            this.contribuinte = contribuinte;
            this.nome = nome;
            this.morada = morada;
            this.nacionalidade = nacionalidade;
            this.contacto = contacto;
            this.dataNascimento = dataNascimento;
            this.metodoPagamento = metodoPagamento;
            this.iban = iban;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getPassword()
        {
            return this.password;
        }

        public int getTipoUtilizador()
        {
            return this.idTipoUtilizador;
        }

        public int getContribuinte()
        {
            return this.contribuinte;
        }

        public string getNome()
        {
            return this.nome;
        }

        public string getMorada()
        {
            return this.morada;
        }

        public string getNacionalidade()
        {
            return this.nacionalidade;
        }

        public string getContacto()
        {
            return this.contacto;
        }

        public DateOnly getDataNascimento()
        {
            return this.dataNascimento;
        }

        public int getMetodoPagamento()
        {
            return this.metodoPagamento;
        }

        public string getIban()
        {
            return this.iban;
        }
        
        public Utilizador Clone()
        {
            return new Utilizador(email,password,idTipoUtilizador,contribuinte,nome,morada,nacionalidade,contacto,dataNascimento,metodoPagamento,iban);
        }
    }
}