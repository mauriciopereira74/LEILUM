



namespace Leilum.LeilumLN.Categoria{
    
    public class Categoria{
        private int id_categoria;
        private string designacao;
        private int id_regras;
    
    
        public Categoria(int idCategoria, string designacao, int idRegras){
            this.id_categoria = idCategoria;
            this.designacao = designacao;
            this.id_regras = idRegras;
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

        public int getIdRegras(){
            return id_regras;
        }

        public void setIdRegras(int idRegras){
            this.id_regras = idRegras;
        }

        public Categoria Clone(){
            Categoria result = new Categoria(id_categoria,designacao,id_regras);
            return result;
        }
    }
}