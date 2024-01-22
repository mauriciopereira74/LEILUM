
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

        public bool existsNIF(int nif)
        {
            return db.existsNIF(nif);
        }

        public Utilizador getUtilizadorWithEmail(string email){
            return db.getUtilizadorWithEmail(email);
        }

        public bool validateNewAccount(string email, int nif){
            return !db.existsEmail(email) && !db.existsNIF(nif);
        }

        public void updateUtilizador(Utilizador utilizador){
             this.db.updateUtilizador(utilizador);
        }

        public bool adicionaConta(Utilizador utilizador){
            if (this.validateNewAccount(utilizador.getEmail(),utilizador.getContribuinte()))
            {
                this.db.addUtilizador(utilizador);
                return true;
            }
            return false;
        }

        public IEnumerable<Leilao> getLeiloesEmCurso(){
            return this.db.getLeiloesEmCurso();
        }

        public IEnumerable<Leilao> getLeiloesPendentesPorCategoria(int categoria)
        {
            return this.db.getLeiloesPendentes(categoria);
        }

        public void startAuction(int auctionId, int bvalue, int mvalue, int ovalue ,string evaluator)
        {
            this.db.atualizaValorBaseLeilaoEstado(auctionId, bvalue, mvalue, ovalue, evaluator);
        }

        public Categoria getCategoriaAvaliador(string email)
        {
            return this.db.getCategoriaAvaliador(email);
        }

        public Leilao getLeilao(int idLeilao){
            return this.db.getLeilao(idLeilao);
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

        public int quantidadeLotes(){
           return this.db.quantidadeLotes(); 
        }
        
        // Adiciona um Leilão
        public void addLeilao(Leilao leilao){
            this.db.addLeilao(leilao);
        }
        
        // Cria um Leilão
        public void criaLeilao(string titulo, DateTime dataFinal, double valorAbertura, double valorBase,
            double valorMinimo, double valorAtual, int estado, Utilizador avaliador, Utilizador comitente,
            Lote lote, Categoria categoria)
        {
            int idLeilao = this.db.quantidadeLeiloes() + 1;
            Leilao l = new Leilao(idLeilao, titulo, dataFinal, valorAbertura, valorBase, valorMinimo, valorAtual,
                estado, avaliador, comitente, lote, categoria);
            addLeilao(l);
        }
        
        // Adiciona um Artigo a uma lista de artigos de um Lote
        public void adicionaArtigoLote(Artigo artigo)
        {
            this.db.adicionaArtigo(artigo);
        }

        // Adiciona uma licitação a um leilão.
        public bool addLicitacao(int idLeilao, string userEmail, double value)
        {
            return this.db.addLicitacao(value,idLeilao,userEmail);
        }

        public List<Categoria> GetAllCategorias(){
            return this.db.GetAllCategorias();
        }
        
        
        
        // Função para buscar leilões em que o Utilizador foi Avaliador   (TALVEZ)  
        
        // Função para buscar leilões em que o Utilizador ganhou
        
    }
}
