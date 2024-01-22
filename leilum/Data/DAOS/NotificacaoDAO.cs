using Dapper;
using Leilum.LeilumLN.NotificacaoLN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Leilum.Data.DAOS
{
    internal class NotificacaoDAO
    {
        private static NotificacaoDAO? singleton = null;

        public static NotificacaoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new NotificacaoDAO();
            }
            return singleton;
        }

        public Notificacao? get(int idNotificacao)
        {
            Notificacao? result = null;
            string sql_cmd = $"SELECT * FROM LEILUM.Notificacao WHERE idNotificacao = '{idNotificacao}'";
            try
            {
                using (SqlConnection con = new (DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    Notificacao aux = con.QueryFirst<Notificacao>(sql_cmd);
                    result = aux;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }

        public void put(Notificacao value)
        {
            string sql_cmd = "INSERT INTO Notificacao (idUtilizador, MensagemNotificacao, DataNotificacao) " +
                            "VALUES (@IdUtilizador, @MensagemNotificacao, @DataNotificacao);";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        con.Open();

                        cmd.Parameters.AddWithValue("@IdUtilizador", value.getidUtilizador());
                        cmd.Parameters.AddWithValue("@MensagemNotificacao", value.getMensagemNotificacao());
                        cmd.Parameters.AddWithValue("@DataNotificacao", value.getDataNotificacao());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Notificacao? remove(int key)
        {
            Notificacao? notificacao = get(key);
            string sql_cmd = $"DELETE FROM LEILUM.Notificacao WHERE idNotificacao = {key}";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return notificacao;
        }

        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador)
        {
            List<Notificacao> result = new List<Notificacao>();
            string sql_cmd = $"SELECT * FROM Notificacao WHERE idUtilizador = '{idUtilizador}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    result = con.Query<Notificacao>(sql_cmd).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
