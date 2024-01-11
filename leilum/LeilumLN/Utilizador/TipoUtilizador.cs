



namespace Leilum.LeilumLN.Utilizador{

    public class TipoUtilizador{

        private int id_utilizador;
        private string role;
    

        public TipoUtilizador(int idUtilizador, string role){
            this.id_utilizador = idUtilizador;
            this.role = role;
        }
    
        public int getIdUtilizador(){
            return id_utilizador;
        }
    
        public void setIdUtilizador(int idUtilizador){
            this.id_utilizador = idUtilizador;
        }
    
        public string getRole(){
            return role;
        }
    
        public void setRole(string role){
            this.role = role;
        }
    
        public TipoUtilizador Clone(){
            TipoUtilizador result = new TipoUtilizador(id_utilizador, role);
            return result;
        }
    }
}