




namespace Leilum.LeilumLN.Leilao{

    public class Leilao{

        private int nrLeilao;
        private string titulo;
        private DateTime duracao;
        private double valorAbertura;
        private double valorBase;
        private double valorMinimo;
        private double valorAtual;
        private int estado;
        private int avaliador;
        private int id_comitente;
        private int lote_id; 
        private int categoria_id;


        public Leilao(int nrLeilao, string titulo, DateTime duracao, double valorAbertura, double valorBase, double valorMinimo, double valorAtual, int estado
                     , int avaliador, int idComitente, int loteId, int categoriaId){

            this.nrLeilao = nrLeilao;
            this.titulo = titulo;
            this.duracao = duracao;
            this.valorAbertura = valorAbertura;
            this.valorBase = valorBase;
            this.valorMinimo = valorMinimo;
            this.valorAtual = valorAtual;
            this.estado = estado;
            this.avaliador = avaliador;
            this.id_comitente = idComitente;
            this.lote_id = loteId;
            this.categoria_id = categoriaId;
        }

        public int getNrLeilao(){
            return nrLeilao;
        }

        public void setNrLeilao(int nrLeilao){
            this.nrLeilao = nrLeilao;
        }

        public string getTitutlo(){
            return titulo;
        }

        public void setTitulo(string titulo){
            this.titulo = titulo;
        }

        public DateTime getDuracao(){
            return duracao;
        }

        public void setDuracao(DateTime duracao){
            this.duracao = duracao;
        }

        public double getValorAbertura(){
            return valorAbertura;
        }

        public void setValorAbertura(double valorAbertura){
            this.valorAbertura = valorAbertura;
        }

        public double getValorBase(){
            return valorBase;
        }

        public void setValorBase(double valorBase){
            this.valorBase = valorBase;
        }

        public double getValorMinimo(){
            return valorMinimo;
        }

        public void setValorMinimo(double valorMinimo){
            this.valorMinimo = valorMinimo;
        }

        public double getValorAtual(){
            return valorAtual;
        }

        public void setValorAtual(double valorAtual){
            this.valorAtual = valorAtual;
        }

        public int getEstado(){
            return estado;
        }

        public void setEstado(int estado){
            this.estado = estado;
        }

        public int getAvaliador(){
            return avaliador;
        }

        public void setAvaliador(int avaliador){
            this.avaliador = avaliador;
        }

        public int getIdComitente(){
            return id_comitente;
        }

        public void setIdComitente(int idComitente){
            this.id_comitente = idComitente;
        }

        public int getIdLote(){
            return lote_id;
        }

        public void setLoteId(int loteId){
            this.lote_id = loteId;
        }

        public int getCategoriaId(){
            return categoria_id;
        }

        public void setCategoriaId(int categoriaId){
            this.categoria_id = categoriaId;
        }

        public Leilao Clone(){
            Leilao result = new Leilao(nrLeilao,titulo,duracao,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,id_comitente,lote_id,categoria_id);
            return result;
        }
    }
}