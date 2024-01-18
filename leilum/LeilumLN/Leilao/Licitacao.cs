
namespace Leilum.LeilumLN.LeilaoLN{

    public class Licitacao{

        private int id_licitacao;
        private string id_licitador;
        private int id_leilao;
        private double valor;
    

        public Licitacao(int idLicitacao, string idLicitador, int idLeilao, double valor){
            this.id_licitacao = idLicitacao;
            this.id_licitador = idLicitador;
            this.id_leilao = idLeilao;
            this.valor = valor;
        }
    
        public int getIdLicitacao(){
            return id_licitacao;
        }
    
        public void setIdLicitacao(int idLicitacao){
            this.id_licitacao = idLicitacao;
        }
    
        public string getIdLicitador(){
            return id_licitador;
        }
    
        public void setIdLicitador(string idLicitador){
            this.id_licitador = idLicitador;
        }
    
        public int getIdLeilao(){
            return id_leilao;
        }
    
        public void setIdLeilao(int idLeilao){
            this.id_leilao = idLeilao;
        }
    
        public double getValor(){
            return valor;
        }
    
        public void setValor(double valor){
            this.valor = valor;
        }
    
        public Licitacao Clone(){
            Licitacao result = new Licitacao(id_licitacao,id_licitador,id_leilao,valor);
            return result;
        }
    }
}