
using Leilum.LeilumLN.ArtigoLN;

namespace Leilum.LeilumLN.LoteLN{

    public class Lote{

        private int id_lote;
        private string id_comitente;
        private string id_comprador;
        private string id_avaliador;
        private string imgPath;
        private List<Artigo> artigos;

        public Lote(int idLote, string idComitente, string idComprador, string idAvaliador, string imgPath, List<Artigo> artigos){
            this.id_lote = idLote;
            this.id_comitente = idComitente;
            this.id_comprador = idComprador;
            this.id_avaliador = idAvaliador;
            this.imgPath = imgPath;
            this.artigos = artigos;
        }

        public int getIdLote(){
            return id_lote;
        }

        public void setIdLote(int idLote){
            this.id_lote = idLote;
        }

        public string getIdComitente(){
            return id_comitente;
        }

        public void setIdComitente(string idComitente){
            this.id_comitente = idComitente;
        }

        public string getIdComprador(){
            return id_comprador;
        }

        public void setIdComprador(string idComprador){
            this.id_comprador = idComprador;
        }

        public string getIdAvaliador(){
            return id_avaliador;
        }

        public void setIdAvaliador(string idAvaliador){
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

        public void addArtigo(Artigo a) {
            artigos.Add(a);
        }

        public List<Artigo> getArtigos(){
            List<Artigo> lista = new List<Artigo>();
            foreach (Artigo artigo in artigos){
                lista.Add(artigo);
            }
            return lista;
        }


        public Lote Clone(){
            Lote result = new Lote(id_lote,id_comitente,id_comprador,id_avaliador,imgPath,artigos);
            return result;
        }
    }
}