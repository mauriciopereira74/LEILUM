
namespace Leilum.LeilumLN.CategoriaLN{

    public class Regra{
        private int id_regra;
        private double valorMinimo;
        private double valorMaximo;
    

        public Regra(int idRegra, double valorMinimo, double valorMaximo){
            this.id_regra = idRegra;
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
        }
    
        public int getIdRegra(){
            return id_regra;
        }
    
        public void setIdRegra(int idRegra){
            this.id_regra = id_regra;
        }
        public double getValorMinimo(){
            return valorMinimo;
        }
    
        public void setValorMinimo(double valorMinimo){
            this.valorMinimo = valorMinimo;
        }
    
        public double getValorMaximo(){
            return valorMaximo;
        }
    
        public void setValorMaximo(double valorMaximo){
            this.valorMaximo = valorMaximo;
        }
    
        public Regra Clone(){
            Regra result = new Regra(id_regra,valorMinimo,valorMaximo);
            return result;
        }
    }
}