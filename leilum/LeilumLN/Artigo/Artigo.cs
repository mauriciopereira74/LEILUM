namespace Leilum.LeilumLN.ArtigoLN{

    public class Artigo
    {
        private string filepath = "";
        private int id_artigo;
        private string designacao;
        private string caracteristicas;
        private string descricao;
        private int lote_id;
    

        public Artigo(int idArtigo, string designacao, string caracteristicas, string descricao, int loteId){
            this.id_artigo = idArtigo;
            this.designacao = designacao;
            this.caracteristicas = caracteristicas;
            this.descricao = descricao;
            this.lote_id = loteId;
        }
        
        public Artigo(int idArtigo, string designacao, string caracteristicas, string descricao, int loteId, string filePath){
            this.id_artigo = idArtigo;
            this.designacao = designacao;
            this.caracteristicas = caracteristicas;
            this.descricao = descricao;
            this.lote_id = loteId;
            this.filepath = filePath;
        }

        public int getId_Artigo(){
            return id_artigo;
        }

        public void setId_Artigo(int id){
            this.id_artigo = id;
        }

        public string getImagPath()
        {
            return this.filepath;
        }

        public void setImagPath(string imagPath)
        {
            this.filepath = imagPath;
        }

        public string getDesignacao(){
            return designacao;
        }

        public void setDesignacao(string designacao){
            this.designacao = designacao;
        }

        public string getCaracteristicas(){
            return caracteristicas;
        }

        public void setCaracteristicas(string caracteristicas){
            this.caracteristicas = caracteristicas;
        }

        public string getDescricao(){
            return descricao;
        }

        public void setDescricao(string descricao){
            this.descricao = descricao;
        }

        public int getLoteId(){
            return lote_id;
        }

        public void setLoteId(int lote_id){
            this.lote_id = lote_id;
        }

        public Artigo Clone(){
            Artigo result = new Artigo(id_artigo,designacao,caracteristicas,descricao,lote_id);
            return result;
        }
    }
}