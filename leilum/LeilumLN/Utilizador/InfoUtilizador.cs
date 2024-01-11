



namespace Leilum.LeilumLN.Utilizador{

    public class InfoUtilizador{

        private int contribuinte;
        private string utilizador_email;
        private string nome;
        private string morada;
        private string nacionalidade;
        private string contacto;
        private DateTime dataNascimento;
        private int metodoPagamento;
        private string iban;
    

        public InfoUtilizador(int contribuinte, string email, string nome, string morada, string nacionalidade, string contacto, DateTime dataNascimento, int metodoPagamento, string iban){
            this.contribuinte = contribuinte;
            this.utilizador_email = email;
            this.nome = nome;
            this.morada = morada;
            this.nacionalidade = nacionalidade;
            this.contacto = contacto;
            this.dataNascimento = dataNascimento;
            this.metodoPagamento = metodoPagamento;
            this.iban = iban;
        }
    
        public int getContribuinte(){
            return contribuinte;
        }
    
        public void setContribuinte(int contribuinte){
            this.contribuinte = contribuinte;
        }
    
        public string getUtilizadorEmail(){
            return utilizador_email;
        }
    
        public void setUtilizadorEmail(string email){
            this.utilizador_email = email;
        }
    
        public string getNome(){
            return nome;
        }
    
        public void setNome(string nome){
            this.nome = nome;
        }
    
        public string getMorada(){
            return morada;
        }
    
        public void setMorada(string morada){
            this.morada = morada;
        }
    
        public string getNacionalidade(){
            return nacionalidade;
        }
    
        public void setNacionalidade(string nacionalidade){
            this.nacionalidade = nacionalidade;
        }
    
        public string getContacto(){
            return contacto;
        }
    
        public void setContacto(string contacto){
            this.contacto = contacto;
        }
    
        public DateTime getDataNascimento(){
            return dataNascimento;
        }
    
        public void setDataNascimento(DateTime dataNascimento){
            this.dataNascimento = dataNascimento;
        }
    
        public int getMetodoPagamento(){
            return metodoPagamento;
        }
    
        public void setMetodoPagamento(int metodoPagamento){
            this.metodoPagamento = metodoPagamento;
        }
    
        public string getIban(){
            return iban;
        }
    
        public void setIban(string iban){
            this.iban = iban;
        }
    
        public InfoUtilizador Clone(){
            InfoUtilizador result = new InfoUtilizador(contribuinte,utilizador_email,nome,morada,nacionalidade,contacto,dataNascimento,metodoPagamento,iban);
            return result;
        }
    }
}