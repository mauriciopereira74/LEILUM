using Leilum.LeilumLN.LoteLN;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.LeilumLN.CategoriaLN;
using System.Globalization;

namespace Leilum.LeilumLN.LeilaoLN{

    public class Leilao{

        private int nrLeilao;
        private string titulo;
        private DateTime dataFinal;
        private double valorAbertura;
        private double valorBase;
        private double valorMinimo;
        private double valorAtual;
        private int estado;
        private Utilizador avaliador;
        private Utilizador comitente;
        private Lote lote; 
        private Categoria categoria;


        public Leilao(int nrLeilao, string titulo, DateTime dataFinal, double valorAbertura, double valorBase, double valorMinimo, double valorAtual, int estado
                     , Utilizador avaliador, Utilizador comitente, Lote lote, Categoria categoria){

            this.nrLeilao = nrLeilao;
            this.titulo = titulo;
            this.dataFinal = dataFinal;
            this.valorAbertura = valorAbertura;
            this.valorBase = valorBase;
            this.valorMinimo = valorMinimo;
            this.valorAtual = valorAtual;
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

        public DateTime getDataFinal(){
            return dataFinal;
        }

        public string getDataFinalSTR(){
            return this.dataFinal.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public void setDuracao(string dataFinalString){
        DateTime dataFinal;
        if (DateTime.TryParseExact(dataFinalString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataFinal))
        {
            this.dataFinal = dataFinal;
        }
        else
        {
            // Lida com o caso em que a conversão falhou
            throw new ArgumentException("Formato de data inválido", nameof(dataFinalString));
        }
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

        public double getvalorAtual(){
            return valorAtual;
        }

        public void setLicitacaoAtual(double valorAtual){
            this.valorAtual = valorAtual;
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
            Leilao result = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);
            return result;
        }
    }
}