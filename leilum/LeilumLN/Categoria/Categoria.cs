
namespace Leilum.LeilumLN.CategoriaLN{
    
    public class Categoria{
        private int id_categoria;
        private string designacao;

        public int IdCategoria => getIdCategoria();
        public string Designacao => getDesignacao();
        private Regra regra;
    
    
        public Categoria(int idCategoria, string designacao, Regra regra){
            this.id_categoria = idCategoria;
            this.designacao = designacao;
            this.regra = regra;
        }

        public int getIdCategoria(){
            return id_categoria;
        }

        public void setIdCategoria(int idCategoria){
            this.id_categoria = idCategoria;
        }

        public string getDesignacao(){
            return designacao;
        }

        public void setDesignacao(string designacao){
            this.designacao = designacao;
        }

        public Regra getRegra(){
            return regra;
        }

        public void setRegra(Regra regra){
            this.regra = regra;
        }

        public Categoria Clone(){
            Categoria result = new Categoria(id_categoria,designacao,regra);
            return result;
        }
    }
}