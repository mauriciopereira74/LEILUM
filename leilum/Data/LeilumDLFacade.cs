using System.Data;
using System.Data.SqlClient;
using Leilum.Data.DAOS;
using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.UtilizadorLN;
using Leilum.LeilumLN.LeilaoLN;
using Leilum.LeilumLN.CategoriaLN;
using System.Data.SqlClient;
using Dapper;
using Leilum.LeilumLN.LoteLN;
using Leilum.LeilumLN.ArtigoLN;
using Leilum.LeilumLN.NotificacaoLN;

namespace Leilum.Data
{
    public class LeilumDLFacade : ILeilumDL
    {
        private ArtigoDAO artigoDAO;
        private CategoriaDAO categoriaDAO;
        private RegraDAO regraDAO;
        private UtilizadorDAO utilizadorDAO;
        private LeilaoDAO leilaoDao;
        private LoteDAO loteDao;
        private LicitacaoDAO licitacaoDao;

        private NotificacaoDAO notificacaoDao;

        public LeilumDLFacade()
        {
            this.artigoDAO = ArtigoDAO.getInstance();
            this.categoriaDAO = CategoriaDAO.getInstance();
            this.regraDAO = RegraDAO.getInstance();
            this.utilizadorDAO = UtilizadorDAO.getInstance();
            this.leilaoDao = LeilaoDAO.getInstance();
            this.loteDao = LoteDAO.getInstance();
            this.licitacaoDao = LicitacaoDAO.getInstance();
            this.notificacaoDao = NotificacaoDAO.getInstance();
        }        
        
        // Utilizadores

        public bool existsEmail(string email)
        {   
            return this.utilizadorDAO.existsEmail(email);
        }

        public bool existsNIF(int nif)
        {
            return this.utilizadorDAO.containsNif(nif);
        }

        public bool existsUtilizador(int nif)
        {
            return this.utilizadorDAO.containsNif(nif);
        }

        public bool existsUtilizador(Utilizador utilizador)
        {
            return this.utilizadorDAO.containsValue(utilizador);
        }

        public Utilizador getUtilizador(int nif)
        {
            return this.utilizadorDAO.getByNif(nif);
        }

        public Utilizador getUtilizadorWithEmail(string email)
        {
            return this.utilizadorDAO.getUtilizadorWithEmail(email);
        }

        public void updateUtilizador(Utilizador utilizador){
            this.utilizadorDAO.update(utilizador);
        }

        public void addUtilizador(Utilizador utilizador)
        {
            this.utilizadorDAO.put(utilizador);
        }

        public void removeUtilizador(int nif)
        {
            this.utilizadorDAO.remove(nif);
        }

        public void removeUtilizador(string email)
        {
            this.utilizadorDAO.remove(this.utilizadorDAO.getUtilizadorWithEmail(email).getContribuinte());
        }

        public IEnumerable<Utilizador> getAllUtilizadores()
        {
            return this.utilizadorDAO.values();
        }

        public IEnumerable<Utilizador> getAllClientes()
        {
            int tipo = 0;
            string sql_cmd = "SELECT Tipo FROM TipoUtilizador WHERE Role = 'Cliente'";

            try {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString())) {
                    con.Open();

                    using(SqlCommand cmdSelect = new SqlCommand(sql_cmd, con)) {
                        using (SqlDataReader reader = cmdSelect.ExecuteReader()) {
                            if (reader.Read()) {
                                tipo = Convert.ToInt32(reader["Tipo"]);
                            }
                        }
                    }
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }

            return this.utilizadorDAO.getAllClientes(tipo);
        }

        
        //Verifica Utilizador 
        public bool verificaUtilizador(string email, string password) {
            Utilizador u = this.utilizadorDAO.getUtilizadorWithEmail(email);
            if (u != null) {
                if (u.getPassword() == password) return true;
            }
            return false;
        }
                
        // Regista Utilizador
        public void registaUtilizador(Utilizador u) {
            if (existsEmail(u.getEmail())) {
                Console.Write("Já existe um Utilizador com esse email!");
                return;
            }
            addUtilizador(u);
        }

        // Atualiza perfil utilizador
        public void atualizaPerfil(Utilizador u) {
            removeUtilizador(u.getEmail());
            addUtilizador(u);
        }
        

        // Get Leilao
        public Leilao getLeilao(int idLeilao){
            Leilao? leilao = null;
            string s_cmd = $"SELECT * FROM Leilao WHERE idLeilao = {idLeilao}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);

                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);

                                leilao = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leilao;
        }
        
        // Adiciona Leilão
        public void addLeilao(Leilao leilao)
        {
            this.leilaoDao.put(leilao.getNrLeilao(),leilao);
        }

        public void UpdateDataFinal(int idLeilao, string newDataFinal)
        {
            string sql_cmd = $"UPDATE Leilao SET DataFim = '{newDataFinal}' WHERE idLeilao = {idLeilao};";

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
                throw new Exception($"Failed to update DataFinal for Leilao with idLeilao {idLeilao}: {e.Message}");
            }
        }
        
        // Get lista de leilões em curso e outro para leilões terminados e outro para leiloes pendentes
        public IEnumerable<Leilao> getLeiloesPendentes(int _categoria, string email){
            IEnumerable<Leilao> leiloesPendentes = new HashSet<Leilao>();
            string s_cmd = $"SELECT * FROM Leilao WHERE Estado = 2 and Categoria = {_categoria} and Comitente <> '{email}'";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);

                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);
                                leiloesPendentes = leiloesPendentes.Append(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesPendentes;
        }

        public IEnumerable<Leilao> getLeiloesEmCurso(){
            IEnumerable<Leilao> leiloesAtivos = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM Leilao WHERE Estado = 1";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);

                                leiloesAtivos = leiloesAtivos.Append(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesAtivos;
        }

        public Categoria? getCategoriaAvaliador(string email)
        {
            string sql_cmd = $"SELECT Categoria FROM Avaliador WHERE Avaliador = '{email}'";
            int idCategoria = -1;
            Categoria categoria = null;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idCategoria = Convert.ToInt32(reader["Categoria"]);
                            }
                        }
                    }
                }

                if (idCategoria != -1)
                {
                    categoria = getCategoria(idCategoria);
                }

                return categoria;
            }
            catch (Exception e)
            {
                throw new DAOException("getCategoriaAvaliador: " + e.Message);
            }
        }

        public void setCategoriaAvaliador(string email, int categoria) {
            string sql_cmdAvaliador = "INSERT INTO Avaliador (Avaliador, Categoria) VALUES ('" + email + "','" + categoria + "');";
            int tipo = 0;
            string sql_getTipo = "SELECT Tipo FROM TipoUtilizador WHERE Role = 'Avaliador'";
            string sql_setTipo = $"UPDATE Utilizador SET TipoUtilizador = @Tipo WHERE Email = @Email";

            try {
                using(SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString())) {
                    con.Open();

                    // Inserir Avaliador
                    using(SqlCommand cmdInsert = new SqlCommand(sql_cmdAvaliador, con)) {
                        cmdInsert.ExecuteNonQuery();
                    }

                    // Obter Tipo
                    using(SqlCommand cmdSelect = new SqlCommand(sql_getTipo, con)) {
                        using (SqlDataReader reader = cmdSelect.ExecuteReader()) {
                            if (reader.Read()) {
                                tipo = Convert.ToInt32(reader["Tipo"]);
                            }
                        }
                    }

                    // Atualizar TipoUtilizador
                    using(SqlCommand cmdUpdate = new SqlCommand(sql_setTipo, con)) {
                        cmdUpdate.Parameters.AddWithValue("@Tipo", tipo);
                        cmdUpdate.Parameters.AddWithValue("@Email", email);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        
        public Categoria getCategoria(int CategoriaId){
            Categoria? result = null;
            string s_cmd = $"SELECT * FROM Categoria WHERE idCategoria = {CategoriaId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idCategoria = Convert.ToInt32(reader["idCategoria"]);
                                string? designacao = Convert.ToString(reader["Designacao"]);
                                int idRegra = Convert.ToInt32(reader["Regra"]);

                                Regra regra = this.regraDAO.get(idRegra);

                                result = new Categoria(idCategoria,designacao,regra);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return result;
        }

        public IEnumerable<Leilao> getLeiloesTerminados(){
            IEnumerable<Leilao> leiloesTerminados = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM Leilao WHERE Estado = 0";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);

                                leiloesTerminados = leiloesTerminados.Append(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesTerminados;
        }
        
        public IEnumerable<Leilao> getLeiloesPendentes(){
            IEnumerable<Leilao> leiloesPendentes = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM Leilao WHERE Estado = 2";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = getLote(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);

                                Leilao leilao = new Leilao(nrLeilao,titulo,dataFinal,valorAbertura,valorBase,valorMinimo,valorAtual,estado,avaliador,comitente,lote,categoria);

                                leiloesPendentes = leiloesPendentes.Append(leilao);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesPendentes;
        }

        public IEnumerable<Leilao> getLeiloesParticipados(string utilizadorEmail){
            IEnumerable<Leilao> leiloesParticipados = new HashSet<Leilao>();
            List<int> idsLeiloes = new List<int>();
            string sql_cmd = $"SELECT * FROM Licitacao WHERE Licitador = '{utilizadorEmail}'";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int idLeilao = Convert.ToInt32(reader["Leilao"]);
                                if (!idsLeiloes.Contains(idLeilao)){
                                    idsLeiloes.Add(idLeilao);
                                }
                            }

                            foreach(int id in idsLeiloes){
                                leiloesParticipados = leiloesParticipados.Append(getLeilao(id));
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesParticipados;
        }

        public IEnumerable<Leilao> getLeiloesCriados(string utilizadorEmail){
            IEnumerable<Leilao> leiloesCriados = new HashSet<Leilao>();
            string sql_cmd = $"SELECT * FROM Leilao WHERE Comitente = '{utilizadorEmail}'";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read()){
                                int idLeilao = Convert.ToInt32(reader["idLeilao"]);
                                leiloesCriados = leiloesCriados.Append(getLeilao(idLeilao));
                            }
                            
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesCriados;
        }

        public IEnumerable<Leilao> getLeiloesGanhos(string utilizadorEmail){
            IEnumerable<Leilao> leiloesGanhos = new HashSet<Leilao>();
            IEnumerable<Leilao> leiloesTerminados = getLeiloesTerminados();

            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    conn.Open();
                    foreach (Leilao leilao in leiloesTerminados){
                        int idLeilao = leilao.getNrLeilao();
                        double valorAtual = leilao.getvalorAtual();

                        string sql_cmd = $"SELECT * FROM Licitacao WHERE Leilao = '{idLeilao}' AND Valor = '{valorAtual}'";

                        using (SqlCommand cmd = new SqlCommand(sql_cmd,conn)){
                            using (SqlDataReader reader = cmd.ExecuteReader()){
                                if (reader.Read()){
                                    string email = Convert.ToString(reader["Licitador"]);

                                    if (email == utilizadorEmail){
                                        leiloesGanhos = leiloesGanhos.Append(getLeilao(idLeilao));
                                    }
                                }
                            }
                        }

                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return leiloesGanhos;
        }

        public IEnumerable<Leilao> getLeiloesRecomendados(string utilizadorEmail){
            IEnumerable<Leilao> leiloesRecomendados = new HashSet<Leilao>();
            IEnumerable<Leilao> leiloesParticipados = getLeiloesParticipados(utilizadorEmail);
            IEnumerable<Leilao> leiloesEmCurso = getLeiloesEmCurso();
            List<string> categorias = new List<string>();

            foreach(Leilao leilao in leiloesParticipados){
                Categoria categoria = leilao.getCategoria();
                if(!categorias.Contains(categoria.getDesignacao())){
                    categorias.Add(categoria.getDesignacao());
                }
            }

            foreach(Leilao leilao1 in leiloesEmCurso){
                Categoria categoria1 = leilao1.getCategoria();
                if(categorias.Contains(categoria1.getDesignacao())){
                    leiloesRecomendados = leiloesRecomendados.Append(leilao1);
                }
            }

            return leiloesRecomendados;
        }

        public double getGastosTotaisUtilizador(string utilizadorEmail){
            IEnumerable<Leilao> leiloesGanhos = getLeiloesGanhos(utilizadorEmail);
            double gastos = 0;

            foreach (Leilao leilao in leiloesGanhos){
                gastos += leilao.getvalorAtual();
            }

            return gastos;
        }
        
        
        // Calcula o número de Leilões existentes na base de dados
        public int quantidadeLeiloes()
        {
            return this.leilaoDao.size();
        }

        public void rejeitaLeilao(int idLeilao, string avaliador)
        {
            using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        var parametros = new
                        {
                            idLeilao,
                            avaliador
                        };
                        string sqlcmd = @"UPDATE Leilao Set Avaliador = @avaliador,
                                            Estado = '3'
                                            Where idLeilao = @idLeilao";
                        int linhas = con.Execute(sqlcmd, parametros, transaction);

                        if (linhas > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            throw new DAOException(
                                "rejeitaLeilao: Nenhuma linha da tabela leilão alterada ao rejeitar o leilão.");
                        }
                    }
                    catch (Exception e)
                    {
                        throw new DataException("rejeitaLeilao: " + e.Message);
                    }
                }
            }
        }

        public void atualizaValorBaseLeilaoEstado(int idLeilao, int valorBase, int valorMinimo, int valorAbertura,
            string avaliador)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        int valorAtual = valorAbertura;
                        var parametros = new
                        {
                            idLeilao,
                            avaliador,
                            valorAbertura,
                            valorMinimo,
                            valorBase,
                            valorAtual
                        };

                        string sql_cmd = @"UPDATE Leilao SET Avaliador = @avaliador,
                                                        Estado = '1',
                                                        ValorAbertura = @valorAbertura,
                                                        ValorMinimo = @valorMinimo,
                                                        ValorBase = @valorBase,
                                                        ValorAtual = @valorAtual
                                                   WHERE idLeilao = @idLeilao";
                        
                        int linhas = con.Execute(sql_cmd, parametros, transaction);

                        if (linhas > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new DAOException("atualizaValorBaseLeilaoEstado: " + e.Message);
                    }
                }
            }
        }

        public void terminaLeilao(int idLeilao)
        {
            using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        var parametros = new
                        {
                            idLeilao
                        };

                        string sql_cmd = @"UPDATE Leilao SET Estado = '0' WHERE idLeilao = @idLeilao";

                        int linhas = con.Execute(sql_cmd, parametros, transaction);

                        if (linhas > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new DAOException("terminaLeilao: " + e.Message);
                    }
                }
            }
        }
        
        // Adiciona uma Licitação
        public bool addLicitacao(Licitacao licitacao) {
            return addLicitacao(licitacao.getValor(),licitacao.getIdLeilao(),licitacao.getIdLicitador());
        }

        // Remove uma Licitação
        public void removeLicitacao(int idLicitacao) {
            this.licitacaoDao.remove(idLicitacao);
        }
        
        public double? getMaiorLicitacao(int idLeilao)
        {
            string sql_cmd = $"SELECT ValorAtual FROM Leilao WHERE idLeilao = {idLeilao}";

            double? result = null;

            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("ValorAtual")))
                            {
                                result = Convert.ToDouble(reader["ValorAtual"]);
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                throw new DAOException("getMaiorLicitacao: " + e.Message);
            }
        }

        public Utilizador getVencedor(int idLeilao)
        {
            string sql_cmd = $"SELECT TOP 1 Licitador FROM Licitacao WHERE Leilao = {idLeilao} ORDER BY valor DESC";

            string vencedorEmail = null;

            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("Licitador")))
                            {
                                vencedorEmail = reader.GetString(reader.GetOrdinal("Licitador"));
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(vencedorEmail))
                {
                    Utilizador vencedor = getUtilizadorWithEmail(vencedorEmail);

                    return vencedor;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new DAOException("getVencedor: " + e.Message);
            }
        }

        public bool addLicitacao(double value, int idLeilao, string emailUser)
        {   
            bool result = false;
            using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        string sql_cmd = "UPDATE Leilao SET ValorAtual = @value WHERE idLeilao = @idLeilao;";
                        string sql_cmd2 = "INSERT INTO Licitacao (idLicitacao, Valor, Licitador, Leilao) VALUES (@idLicitacao, @value, @emailUser, @idLeilao);";
                        string sql_cmd3 = $"SELECT ValorAtual FROM Leilao WHERE idLeilao = {idLeilao}";
                        using (SqlCommand cmd = new SqlCommand(sql_cmd, con, transaction))
                        using (SqlCommand cmd2 = new SqlCommand(sql_cmd2, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@value", value);
                            cmd.Parameters.AddWithValue("@idLeilao", idLeilao);

                            cmd2.Parameters.AddWithValue("@idLicitacao", licitacaoDao.size());
                            cmd2.Parameters.AddWithValue("@value", value);
                            cmd2.Parameters.AddWithValue("@emailUser", emailUser);
                            cmd2.Parameters.AddWithValue("@idLeilao", idLeilao);

                            cmd.ExecuteNonQuery();
                            cmd2.ExecuteNonQuery();
                            transaction.Commit();
                            result = true;
                            
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new DAOException("DLFACADEDAO addLicitacao: " + e.Message);
                    }
                }
            }
            return result;
        }
                
        // Get categoria pelo Id

        public Categoria getCategoriaById(int CategoriaId){
            Categoria? result = null;
            string s_cmd = $"SELECT * FROM Categoria WHERE idCategoria = {CategoriaId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idCategoria = Convert.ToInt32(reader["idCategoria"]);
                                string? designacao = Convert.ToString(reader["Designacao"]);
                                int idRegra = Convert.ToInt32(reader["Regra"]);

                                Regra regra = this.regraDAO.get(idRegra);

                                result = new Categoria(idCategoria,designacao,regra);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return result;
        }

        // get categoria pela designacao

        public Categoria getCategoriaByDesignacao(string Designacao){
            Categoria? result = null;
            string s_cmd = $"SELECT * FROM Categoria WHERE Designacao = '{Designacao}'";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd,conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idCategoria = Convert.ToInt32(reader["idCategoria"]);
                                string? designacao = Convert.ToString(reader["Designacao"]);
                                int idRegra = Convert.ToInt32(reader["Regra"]);

                                Regra regra = this.regraDAO.get(idRegra);

                                result = new Categoria(idCategoria,designacao,regra);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return result;
        }

        public ICollection<string> getCategoriasList()
        {
            ICollection<string> list = new List<string>();
            string sql_cmd = "SELECT Designacao FROM Categoria;";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(Convert.ToString(reader["Designacao"]));
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new DAOException("getCategoriasSTR: " + e.Message);
            }
        }

        public int getIdCategoria(string designacao)
        {
            int? result = null;
            string sql_cmd = $"Select idCategoria FROM Categoria WHERE Designacao = {designacao};";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = Convert.ToInt32(reader["idCategoria"]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException("getIDCategoria: " + e.Message);
            }
            return result.Value;
        }
        
        public List<Categoria> GetAllCategorias() {
            List<Categoria> categorias = new List<Categoria>();

            string s_cmd = "SELECT * FROM Categoria";

            try {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())) {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, conn)) {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                int idCategoria = Convert.ToInt32(reader["idCategoria"]);
                                string designacao = Convert.ToString(reader["Designacao"]);
                                int idRegra = Convert.ToInt32(reader["Regra"]);

                                Regra regra = this.regraDAO.get(idRegra);

                                Categoria categoria = new Categoria(idCategoria, designacao, regra);
                                categorias.Add(categoria);
                            }
                        }
                    }
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }

            return categorias;
        }
        
        // Adiciona Categoria
        public void addCategoria(Categoria categoria) {
            this.categoriaDAO.put(categoria.getIdCategoria(),categoria);
        }

        // Remove Categoria
        public void removeCategoria(int idCategoria) {
            this.categoriaDAO.remove(idCategoria);
        }
        
        // Get Regra
        public Regra getRegra(int idRegra) {
            return this.regraDAO.get(idRegra);
        }
        
        
        // Adiciona Regra (Admin)
        public void addRegra(Regra regra)
        {
            this.regraDAO.put(regra.getIdRegra(),regra);
        }
        
        // Remove Regra (Admin)
        public void removeRegra(int idRegra)
        {
            this.regraDAO.remove(idRegra);
        }
        
        
        // Calcula o número de Artigos existentes na base de dados
        public int quantidadeArtigos()
        {
            return this.artigoDAO.size();
        }
        
        // Calcula o número de Artigos existentes na base de dados
        public int quantidadeLotes()
        {
            return this.loteDao.size();
        }        
        
        // Função para buscar os leilões em que o Utilizador foi Comitente
        public ICollection<Leilao> getLeiloesComitentes(string uComitente)
        {
            ICollection<Leilao> leiloesComitente = new HashSet<Leilao>();
            string s_cmd = $"SELECT * FROM Leilao WHERE Comitente = {uComitente}";
            try
            {
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int nrLeilao = Convert.ToInt32(reader["idLeilao"]);
                                string? titulo = Convert.ToString(reader["Titulo"]);
                                DateTime dataFinal = Convert.ToDateTime(reader["DataFim"]);
                                double valorAbertura = Convert.ToDouble(reader["ValorAbertura"]);
                                double valorBase = Convert.ToDouble(reader["ValorBase"]);
                                double valorMinimo = Convert.ToDouble(reader["ValorMinimo"]);
                                double valorAtual = Convert.ToDouble(reader["ValorAtual"]);
                                int estado = Convert.ToInt32(reader["Estado"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                int loteId = Convert.ToInt32(reader["Lote"]);
                                int categoriaId = Convert.ToInt32(reader["Categoria"]);

                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Lote lote = this.loteDao.get(loteId);
                                Categoria categoria = getCategoriaById(categoriaId);
                                
                                Leilao leilao = new Leilao(nrLeilao, titulo, dataFinal, valorAbertura, valorBase,
                                    valorMinimo, valorAtual, estado, avaliador, comitente, lote, categoria);
                                leiloesComitente.Add(leilao);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return leiloesComitente;
        }

        public Lote getLote(int loteId){

            Lote? lote = null;
            string s_cmd = $"SELECT * FROM Lote WHERE idLote = {loteId}";
            try{
                using (SqlConnection conn = new SqlConnection(DAOConfig.GetConnectionString())){
                    using (SqlCommand cmd = new SqlCommand(s_cmd, conn)){
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                int idLote = Convert.ToInt32(reader["idLote"]);
                                string? comitenteEmail = Convert.ToString(reader["Comitente"]);
                                string? compradorEmail = Convert.ToString(reader["Comprador"]);
                                string? avaliadorEmail = Convert.ToString(reader["Avaliador"]);
                                string? pathImg = Convert.ToString(reader["ImagPath"]);

                                Utilizador comitente = this.utilizadorDAO.getUtilizadorWithEmail(comitenteEmail);
                                Utilizador comprador = this.utilizadorDAO.getUtilizadorWithEmail(compradorEmail);
                                Utilizador avaliador = this.utilizadorDAO.getUtilizadorWithEmail(avaliadorEmail);
                                
                                lote = new Lote(idLote,comitente,comprador,avaliador,this.artigoDAO.getArtigosLote(loteId), pathImg);
                            }
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception(e.Message);
            }
            return lote;
        }

        public void adicionaArtigo(Artigo artigo){
            this.artigoDAO.put(artigo.getId_Artigo(),artigo);
        }

        public void adcionaLeilao(Leilao leilao){

            this.loteDao.put(leilao.getLote().getIdLote(), leilao.getLote());

            foreach (Artigo a in leilao.getLote().getArtigos()){
                this.artigoDAO.put(a.getId_Artigo(),a);
            }
            
            this.leilaoDao.put(leilao.getNrLeilao(), leilao);
        }

        public List<Notificacao> getNotificacoesPorUtilizador(string idUtilizador){
            return this.notificacaoDao.getNotificacoesPorUtilizador(idUtilizador);
        }

        public void adicionaNotificacao(Notificacao notificacao){
            this.notificacaoDao.put(notificacao);
        }

        public ICollection<string> getListMetodoPagamento()
        {
            ICollection<string> list = new List<string>();
            string sql_cmd = "SELECT Designacao FROM MetodoPagamento";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(Convert.ToString(reader["Designacao"]));
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new DAOException("getListMetodoPagamento: " + e.Message);
            }
        }

        public string getDesignacaoMetodoPagamento(int metodo)
        {
            string result = "";
            string sql_cmd = $"SELECT Designacao FROM MetodoPagamento WHERE Metodo = {metodo}";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = Convert.ToString(reader["Designacao"]);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new DAOException("getDesignacaoMetodoPagamento: " + e.Message);
            }
        }

        public int getIdMetodoPagamentoByDesignacao(string designacao)
        {
            int result = -1;
            string sql_cmd = $"SELECT Metodo FROM MetodoPagamento WHERE Designacao = '{designacao}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOConfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_cmd,con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = Convert.ToInt32(reader["Metodo"]);
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new DAOException("getDesignacaoMetodoPagamento: " + e.Message);
            }
        }

    }
}