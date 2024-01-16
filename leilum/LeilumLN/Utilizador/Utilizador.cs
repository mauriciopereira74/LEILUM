namespace Leilum.LeilumLN.UtilizadorLN{

    public class Utilizador{
        
        private string email { get; set; }
        private string password { get; set; }
        private int idTipoUtilizador { get; set; }
        private string? fotoPerfil { get; set; }
        private int contribuinte { get; set; }
        private string? nome { get; set; }
        private string? morada { get; set; }
        private string? nacionalidade { get; set; }
        private string? contacto { get; set; }
        private DateOnly dataNascimento { get; set; }
        private int metodoPagamento { get; set; }
        private string? iban { get; set; }
        

        public Utilizador(){
            
        }
        public Utilizador(string email, string password, int idTipoUtilizador){
            this.email = email;
            this.password = password;
            this.idTipoUtilizador = idTipoUtilizador;
            this.fotoPerfil = null;
        }

        public Utilizador(string email, string password, int idTipoUtilizador, string fotoPerfil, int contribuinte, string nome, string morada, string nacionalidade, string contacto, DateOnly dataNascimento, int metodoPagamento, string iban){
            this.email = email;
            this.password = password;
            this.idTipoUtilizador = idTipoUtilizador;
            this.fotoPerfil = fotoPerfil;
            this.contribuinte = contribuinte;
            this.nome = nome;
            this.morada = morada;
            this.nacionalidade = nacionalidade;
            this.contacto = contacto;
            this.dataNascimento = dataNascimento;
            this.metodoPagamento = metodoPagamento;
            this.iban = iban;
        }

        public Utilizador(string email, string password, int idTipoUtilizador, string fotoPerfil, int contribuinte, string nome, string morada, string nacionalidade, string contacto, DateTime dataNascimento, int metodoPagamento, string iban){
            this.email = email;
            this.password = password;
            this.idTipoUtilizador = idTipoUtilizador;
            this.fotoPerfil = fotoPerfil;
            this.contribuinte = contribuinte;
            this.nome = nome;
            this.morada = morada;
            this.nacionalidade = nacionalidade;
            this.contacto = contacto;
            this.dataNascimento = DateOnly.FromDateTime(dataNascimento);
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

        public string getFotoPerfil()
        {
            return this.fotoPerfil;
        }

        public void setFotoPerfil(string path)
        {
            this.fotoPerfil = path;
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

        public string getDataNascimentoSTR()
        {
            return this.dataNascimento.ToString("yyyy-MM-dd");
        }

        public DateOnly getDataNascimento(){
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
            return new Utilizador(email,password,idTipoUtilizador,fotoPerfil,contribuinte,nome,morada,nacionalidade,contacto,dataNascimento,metodoPagamento,iban);
        }
    }
}