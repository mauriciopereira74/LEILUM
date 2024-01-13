



namespace Leilum.LeilumLN.Lote{

    public class Lote{

        private int id_lote;
        private int id_comitente;
        private int id_comprador;
        private int id_avaliador;
        private string imgPath;
        
<<<<<<< Updated upstream
=======

        public Lote(int idLote, int idComitente, int idComprador, int idAvaliador, string imgPath){
            this.id_lote = idLote;
            this.id_comitente = idComitente;
            this.id_comprador = idComprador;
            this.id_avaliador = idAvaliador;
            this.imgPath = imgPath;
        }

        public int getIdLote(){
            return id_lote;
        }

        public void setIdLote(int idLote){
            this.id_lote = idLote;
        }

        public int getIdComitente(){
            return id_comitente;
        }

        public void setIdComitente(int idComitente){
            this.id_comitente = idComitente;
        }

        public int getIdComprador(){
            return id_comprador;
        }

        public void setIdComprador(int idComprador){
            this.id_comprador = idComprador;
        }

        public int getIdAvaliador(){
            return id_avaliador;
        }

        public void setIdAvaliador(int idAvaliador){
            this.id_avaliador = idAvaliador;
        }

        public string getImgPath()
        {
            return this.imgPath;
        }

        public void setImgPath(string path)
        {
            this.imgPath = path;
        }

        public Lote Clone(){
            Lote result = new Lote(id_lote,id_comitente,id_comprador,id_avaliador,imgPath);
            return result;
        }
>>>>>>> Stashed changes
    }
}