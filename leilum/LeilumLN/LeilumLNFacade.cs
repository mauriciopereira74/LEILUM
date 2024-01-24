
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.Data;
using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.CategoriaLN;
using Leilum.LeilumLN.LoteLN;
using Leilum.LeilumLN.NotificacaoLN;

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

        public IEnumerable<Leilao> getLeiloesTerminados()
        {
            return this.db.getLeiloesTerminados();
        }
        
        public IEnumerable<Leilao> getLeiloesPendentes()
        {
            return this.db.getLeiloesPendentes();
        }

        public IEnumerable<Leilao> getLeiloesPendentesPorCategoria(int categoria)
        {
            return this.db.getLeiloesPendentes(categoria);
        }

        public IEnumerable<Leilao> getLeiloesParticipados(string email){
            return this.db.getLeiloesParticipados(email);
        }

        public IEnumerable<Leilao> getLeiloesCriados(string utilizadorEmail){
            return this.db.getLeiloesCriados(utilizadorEmail);
        }

        public IEnumerable<Leilao> getLeiloesGanhos(string utilizadorEmail){
            return this.db.getLeiloesGanhos(utilizadorEmail);
        }

        public IEnumerable<Leilao> getLeiloesRecomendados(string utilizadorEmail){
            return this.db.getLeiloesRecomendados(utilizadorEmail);
        }

        public double getGastosTotaisUtilizador(string utilizadorEmail)
        {
            return this.db.getGastosTotaisUtilizador(utilizadorEmail);
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

        public int quantidadeLeiloes() {
            return this.db.quantidadeLeiloes();
        }

        // Cria um Artigo
        public Artigo criaArtigo(string designacao, string caracteristicas, string descricao, int idLote)
        {
            int idArtigo = this.db.quantidadeArtigos() + 1;

            Artigo artigo = new Artigo(idArtigo, designacao, caracteristicas, descricao, idLote);
            return artigo;
        }

        public int quantidadeArtigos(){
            return this.db.quantidadeArtigos();
        }
        
        // Cria um Lote
        public Lote criaLote(Utilizador comitente, Utilizador comprador, Utilizador avaliador, string imgPath,
            List<Artigo> artigos)
        {
            int idLote = this.db.quantidadeLotes() + 1;
            Lote lote = new Lote(idLote, comitente, comprador, avaliador, artigos,imgPath);

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

        public Categoria GetCategoriaByDesignacao(string s) {
            return this.db.getCategoriaByDesignacao(s);
        }

        public void adicionaLeilao(Leilao leilao){
            this.db.adcionaLeilao(leilao);
        }

        public IEnumerable<Utilizador> getAllUtilizadores() {
            return this.db.getAllUtilizadores();
        }

        public IEnumerable<Utilizador> getAllClientes() {
            return this.db.getAllClientes();
        }

        public void promoteUtilizador(Utilizador u, string categoria) {
            string email = u.getEmail();
            Categoria c = this.db.getCategoriaByDesignacao(categoria);

            this.db.setCategoriaAvaliador(email, c.getIdCategoria());
        }
        
        // Função para buscar leilões em que o Utilizador foi Avaliador   (TALVEZ)  
        
        // Função para buscar leilões em que o Utilizador ganhou
        

        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador){
            return this.db.getNotificacoesPorUtilizador(idUtilizador);
        }

        public void adicionaNotificacao(Notificacao notificacao){
            this.db.adicionaNotificacao(notificacao);
        }

        public Dictionary<string, int> CalcularGastosPorMes(int ano)
        {
            IEnumerable<Leilao> leiloes = this.db.getLeiloesTerminados();
            Dictionary<string, int> gastosPorMes = new Dictionary<string, int>();

            // Inicializa o dicionário com gastos zero para cada mês do ano
            for (int i = 1; i <= 12; i++)
            {
                string nomeMes = $"{ano}-{i.ToString("D2")}-01";
                gastosPorMes.Add(nomeMes, 0);
            }

            // Percorre os leilões e atualiza os gastos no dicionário
            foreach (var leilao in leiloes)
            {
                if (leilao.getDataFinal().Year == ano)
                {
                    string nomeMes = leilao.getDataFinal().ToString("yyyy-MM-01");
                    gastosPorMes[nomeMes] += (int)leilao.getvalorAtual();
                }
            }
            return gastosPorMes;
        }
        
        // Para obter uma lista de anos em que ocorream os leiloes que já foram terminados
        public List<int> ObterAnosComLeiloes(IEnumerable<Leilao> leiloes)
        {
            List<int> anosComLeiloes = leiloes
                .Select(leilao => leilao.getDataFinal().Year)
                .Distinct()
                .ToList();

            return anosComLeiloes;
        }

        public ICollection<string> getAllMetodoPagamentos()
        {
            return this.db.getListMetodoPagamento();
        }

        public string getDesignacaoMetodoPagamento(int metodo)
        {
            return db.getDesignacaoMetodoPagamento(metodo);
        }

        public int getIdMetodoPagamento(string designacao)
        {
            return db.getIdMetodoPagamentoByDesignacao(designacao);
        }

    }
}
