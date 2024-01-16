
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.Data;
using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.CategoriaLN;
using Leilum.LeilumLN.LoteLN;

namespace leilum.LeilumLN
{
    public class LeilumLNFacade : ILeilumLN
    {
        private ILeilumDL db; // base de dados

        public LeilumLNFacade()
        {
            this.db = new LeilumDLFacade();
        }

        public bool existsEmail(string email){
            return db.existsEmail(email);
        }

        public Utilizador getUtilizadorWithEmail(string email){
            return db.getUtilizadorWithEmail(email);
        }

        public bool validateNewAccount(string email){
            return !db.existsEmail(email);
        }

        public bool adicionaConta(Utilizador utilizador){
            if (this.validateNewAccount(utilizador.getEmail()))
            {
                this.db.addUtilizador(utilizador);
                return true;
            }
            return false;
        }


        // Cria um Artigo
        public Artigo criaArtigo(string designacao, string caracteristicas, string descricao, int idLote)
        {
            int idArtigo = this.db.quantidadeArtigos() + 1;

            Artigo artigo = new Artigo(idArtigo, designacao, caracteristicas, descricao, idLote);
            return artigo;
        }
        
        // Cria um Lote
        public Lote criaLote(Utilizador comitente, Utilizador comprador, Utilizador avaliador, string imgPath,
            List<Artigo> artigos)
        {
            int idLote = this.db.quantidadeLotes() + 1;
            Lote lote = new Lote(idLote, comitente, comprador, avaliador, imgPath, artigos);

            return lote;
        }
        
        // Adiciona um Leilão
        public void addLeilao(Leilao leilao){
            this.db.addLeilao(leilao);
        }
        
        // Cria um Leilão
        public void criaLeilao(string titulo, DateTime duracao, double valorAbertura, double valorBase,
            double valorMinimo, Licitacao licitacaoAtual, int estado, Utilizador avaliador, Utilizador comitente,
            Lote lote, Categoria categoria)
        {
            int idLeilao = this.db.quantidadeLeiloes() + 1;
            Leilao l = new Leilao(idLeilao, titulo, duracao, valorAbertura, valorBase, valorMinimo, licitacaoAtual,
                estado, avaliador, comitente, lote, categoria);
            addLeilao(l);
        }
        
        // Adiciona um Artigo a uma lista de artigos de um Lote
        public void adicionaArtigoLote(Artigo artigo)
        {
            this.db.adicionaArtigo(artigo);
        }
        
        // Função para buscar leilões em que o Utilizador foi Avaliador   (TALVEZ)  
        
        // Função para buscar leilões em que o Utilizador ganhou
        

    }
}
