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

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string pass)
        {
            this.password = pass;
        }

        public int getTipoUtilizador()
        {
            return this.idTipoUtilizador;
        }

        public void setTipoUtilizador(int tipo)
        {
            this.idTipoUtilizador = tipo;
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

        public void setContribuinte(int contribuinte)
        {
            this.contribuinte=contribuinte;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string nome)
        {
            this.nome=nome;
        }

        public string getMorada()
        {
            return this.morada;
        }

        public void setMorada(string morada)
        {
            this.morada=morada;
        }

        public string getNacionalidade()
        {
            return this.nacionalidade;
        }

        public void setNacionalidade(string nacionalidade)
        {
            this.nacionalidade=nacionalidade;
        }

        public string getContacto()
        {
            return this.contacto;
        }

        public void setContacto(string contacto)
        {
            this.contacto=contacto;
        }

        public string getDataNascimentoSTR()
        {
            return this.dataNascimento.ToString("yyyy-MM-dd");
        }

        public DateOnly getDataNascimento(){
            return this.dataNascimento;
        }

        public void SetDataNascimento(DateTime date)
        {
            this.dataNascimento = DateOnly.FromDateTime(date);
        }

        public int getMetodoPagamento()
        {
            return this.metodoPagamento;
        }

        public void setMetodoPagamento(int metodoPagamento)
        {
            this.metodoPagamento = metodoPagamento;
        }

        public string getIban()
        {
            return this.iban;
        }

        public void setIban(string iban)
        {
            this.iban = iban;
        }
        
        public Utilizador Clone()
        {
            return new Utilizador(email,password,idTipoUtilizador,fotoPerfil,contribuinte,nome,morada,nacionalidade,contacto,dataNascimento,metodoPagamento,iban);
        }
    }
}