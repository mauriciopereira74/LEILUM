using Leilum.LeilumLN.LoteLN;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.LeilumLN.CategoriaLN;

namespace Leilum.LeilumLN.LeilaoLN{

    public class Leilao{

        private int nrLeilao;
        private string titulo;
        private TimeSpan duracao;
        private double valorAbertura;
        private double valorBase;
        private double valorMinimo;
        private Licitacao licitacaoAtual;
        private int estado;
        private Utilizador avaliador;
        private Utilizador comitente;
        private Lote lote; 
        private Categoria categoria;


        public Leilao(int nrLeilao, string titulo, TimeSpan duracao, double valorAbertura, double valorBase, double valorMinimo, Licitacao licitacaoAtual, int estado
                     , Utilizador avaliador, Utilizador comitente, Lote lote, Categoria categoria){

            this.nrLeilao = nrLeilao;
            this.titulo = titulo;
            this.duracao = duracao;
            this.valorAbertura = valorAbertura;
            this.valorBase = valorBase;
            this.valorMinimo = valorMinimo;
            this.licitacaoAtual = licitacaoAtual;
            this.estado = estado;
            this.avaliador = avaliador;
            this.comitente = comitente;
            this.lote = lote;
            this.categoria = categoria;
        }

        public int getNrLeilao(){
            return nrLeilao;
        }

        public void setNrLeilao(int nrLeilao){
            this.nrLeilao = nrLeilao;
        }

        public string getTitulo(){
            return titulo;
        }

        public void setTitulo(string titulo){
            this.titulo = titulo;
        }

        public TimeSpan getDuracao(){
            return duracao;
        }

        public void setDuracao(TimeSpan duracao){
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

        public double getLicitacaoAtual(){
            return licitacaoAtual.getValor();
        }

        public void setLicitacaoAtual(Licitacao licitacao){
            this.licitacaoAtual = licitacao;
        }

        public int getEstado(){
            return estado;
        }

        public void setEstado(int estado){
            this.estado = estado;
        }

        public Utilizador getAvaliador(){
            return avaliador;
        }

        public void setAvaliador(Utilizador avaliador){
            this.avaliador = avaliador;
        }

        public Utilizador getComitente(){
            return comitente;
        }

        public void setComitente(Utilizador comitente){
            this.comitente = comitente;
        }

        public Lote getLote(){
            return lote;
        }

        public void setLote(Lote lote){
            this.lote = lote;
        }

        public Categoria getCategoria(){
            return categoria;
        }

        public void setCategoria(Categoria categoria){
            this.categoria = categoria;
        }

        public bool emCurso() {
            return (this.estado == 1);
        }


        public Leilao Clone(){
            Leilao result = new Leilao(nrLeilao,titulo,duracao,valorAbertura,valorBase,valorMinimo,licitacaoAtual,estado,avaliador,comitente,lote,categoria);
            return result;
        }
    }
}