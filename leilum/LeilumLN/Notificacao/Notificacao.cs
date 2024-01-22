using System;

namespace Leilum.LeilumLN.NotificacaoLN
{
    public class Notificacao
    {
        private int idNotificacao;
        private string idUtilizador;
        private string mensagemNotificacao;
        private DateTime dataNotificacao;

        public Notificacao() { }

        public Notificacao(string idUtilizador, string mensagemNotificacao, DateTime dataNotificacao)
        {   
            this.idUtilizador = idUtilizador;
            this.mensagemNotificacao = mensagemNotificacao;
            this.dataNotificacao = dataNotificacao;
        }

        public int getIdNotificacao()
        {
            return idNotificacao;
        }

        public void setIdNotificacao(int idNotificacao)
        {
            this.idNotificacao = idNotificacao;
        }

        public string getidUtilizador()
        {
            return idUtilizador;
        }

        public void setidUtilizador(string idUtilizador)
        {
            this.idUtilizador = idUtilizador;
        }

        public string getMensagemNotificacao()
        {
            return mensagemNotificacao;
        }

        public void setMensagemNotificacao(string mensagemNotificacao)
        {
            this.mensagemNotificacao = mensagemNotificacao;
        }

        public DateTime getDataNotificacao()
        {
            return dataNotificacao;
        }

        public void setDataNotificacao(DateTime dataNotificacao)
        {
            this.dataNotificacao = dataNotificacao;
        }

        public Notificacao Clone()
        {
            Notificacao result = new Notificacao(idUtilizador, mensagemNotificacao, dataNotificacao);
            return result;
        }
    }
}
