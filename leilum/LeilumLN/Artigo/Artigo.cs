



namespace Leilum.LeilumLN.Artigo {

    public class Artigo{
        private int id_artigo;
        private string designacao;
        private string caracteristicas;
        private string descricao;
        private int lote_id;
    }

    public Artigo(int idArtigo, string designacao, string caracteristicas, string descricao, int loteId)
    {
        this.id_artigo = idArtigo;
        this.designacao = designacao;
        this.caracteristicas = caracteristicas;
        this.descricao = descricao;
        this.lote_id = loteId;
    }


}