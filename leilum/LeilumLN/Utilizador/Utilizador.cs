



namespace Leilum.LeilumLN.Utilizador{

    public class Utilizador{

        private string email;
        private string password;
        private int id_tipoUtilizador;
    

        public Utilizador(string email, string password, int idTipoUtilizador){
            this.email = email;
            this.password = password;
            this.id_tipoUtilizador = idTipoUtilizador;
        }

        public string getEmail(){
            return email;
        }

        public void setEmail(string email){
            this.email = email;
        }

        public string getPassword(){
            return password;
        }

        public void setPassword(string password){
            this.password = password;
        }

        public int getIdTipoUtilizador(){
            return id_tipoUtilizador;
        }

        public void setIdTipoUtilizador(int idTipoUtilizador){
            this.id_tipoUtilizador = idTipoUtilizador;
        }

        public Utilizador Clone(){
            Utilizador result = new Utilizador(email,password,id_tipoUtilizador);
            return result;
        }
    }
}