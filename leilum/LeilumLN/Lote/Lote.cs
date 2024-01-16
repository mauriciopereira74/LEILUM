
using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.UtilizadorLN;

namespace Leilum.LeilumLN.LoteLN{

    public class Lote{

        private int id_lote;
        private Utilizador comitente;
        private Utilizador comprador;
        private Utilizador avaliador;
        private string imgPath;
        private List<Artigo> artigos;

        public Lote(int idLote, Utilizador comitente, Utilizador comprador, Utilizador avaliador, string imgPath, List<Artigo> artigos){
            this.id_lote = idLote;
            this.comitente = comitente;
            this.comprador = comprador;
            this.avaliador = avaliador;
            this.imgPath = imgPath;
            this.artigos = artigos;
        }

        public int getIdLote(){
            return id_lote;
        }

        public void setIdLote(int idLote){
            this.id_lote = idLote;
        }

        public Utilizador getComitente(){
            return comitente;
        }

        public void setComitente(Utilizador comitente){
            this.comitente = comitente;
        }

        public Utilizador getComprador(){
            return comprador;
        }

        public void setComprador(Utilizador comprador){
            this.comprador = comprador;
        }

        public Utilizador getAvaliador(){
            return avaliador;
        }

        public void setAvaliador(Utilizador avaliador){
            this.avaliador = avaliador;
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
            int idArtigo = a.getId_Artigo();
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
            Lote result = new Lote(id_lote,comitente,comprador,avaliador,imgPath,artigos);
            return result;
        }
    }
}