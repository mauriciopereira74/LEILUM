
namespace Leilum.LeilumLN.CategoriaLN{

    public class Regra{
        private int id_regra;
        private DateTime tempoMinimo;
        private DateTime tempoMaximo;
        private double valorMinimo;
        private double valorMaximo;
    

        public Regra(int idRegra, DateTime tempoMinimo, DateTime tempoMaximo, double valorMinimo, double valorMaximo){
            this.id_regra = idRegra;
            this.tempoMinimo = tempoMinimo;
            this.tempoMaximo = tempoMaximo;
            this.valorMinimo = valorMinimo;
            this.valorMaximo = valorMaximo;
        }
    
        public int getIdRegra(){
            return id_regra;
        }
    
        public void setIdRegra(int idRegra){
            this.id_regra = id_regra;
        }
    
        public DateTime getTempoMinimo(){
            return tempoMinimo;
        }
    
        public void setTempoMinimo(DateTime tempoMinimo){
            this.tempoMinimo = tempoMinimo;
        }
    
        public DateTime getTempoMaximo(){
            return tempoMaximo;
        }
    
        public void setTempoMaximo(DateTime tempoMaximo){
            this.tempoMaximo = tempoMaximo;
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
            Regra result = new Regra(id_regra,tempoMinimo,tempoMaximo,valorMinimo,valorMaximo);
            return result;
        }
    }
}