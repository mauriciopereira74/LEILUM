USE master;
GO

CREATE DATABASE LEILUM;
GO

USE LEILUM;
GO

CREATE SCHEMA LEILUM;
GO


-- DROP TABLE LEILUM.TipoUtilizador
CREATE TABLE LEILUM.TipoUtilizador (
	Tipo INT NOT NULL,
	Role VARCHAR(45) NOT NULL,
	PRIMARY KEY (Tipo)
	);

-- DROP TABLE LEILUM.Utilizador;
CREATE TABLE LEILUM.Utilizador (
	Email VARCHAR(45) NOT NULL,
	Password VARCHAR(45) NOT NULL,
	TipoUtilizador INT NOT NULL,
	FOREIGN KEY (TipoUtilizador) REFERENCES LEILUM.TIPOUTILIZADOR (Tipo),
	PRIMARY KEY (Email)
);

-- DROP TABLE LEILUM.InfoUtilizador;
CREATE TABLE LEILUM.InfoUtilizador (
	Contribuinte INT NOT NULL,
	Nome VARCHAR(45) NOT NULL,
	Morada VARCHAR(100) NOT NULL,
	Nacionalidade VARCHAR(45) NOT NULL,
	Contacto VARCHAR(45) NOT NULL,
	DataNascimento DATE NOT NULL,
	MetodoPagamento INT NOT NULL,
	Iban VARCHAR(45) NOT NULL,
	idUtilizador VARCHAR(45) NOT NULL,
	FOREIGN KEY (idUtilizador) REFERENCES LEILUM.Utilizador (Email),
	PRIMARY KEY (Contribuinte));

-- DROP TABLE LEILUM.Lote;
CREATE TABLE LEILUM.Lote (
	idLote INT NOT NULL,
	Comitente VARCHAR(45) NOT NULL,
	Comprador VARCHAR(45) NULL,
	Avaliador VARCHAR(45) NULL,
	Imgpath VARCHAR(500) NOT NULL,
	FOREIGN KEY (Comitente) REFERENCES LEILUM.Utilizador (Email),
	FOREIGN KEY (Comprador) REFERENCES LEILUM.Utilizador (Email),
	FOREIGN KEY (Avaliador) REFERENCES LEILUM.Utilizador (Email),
	PRIMARY KEY (idLote));
	
-- DROP TABLE LEILUM.Artigo;
CREATE TABLE LEILUM.Artigo (
	idArtigo INT NOT NULL,
	Desiganacao VARCHAR(45) NOT NULL,
	Caracteristicas TEXT NOT NULL,
	Descricao TEXT NOT NULL,
	idLote INT NOT NULL,
	FOREIGN KEY (idLote) REFERENCES LEILUM.Lote (idLote),
	PRIMARY KEY (idArtigo));

-- DROP TABLE LEILUM.Regra;
CREATE TABLE LEILUM.Regra (
	idRegra INT NOT NULL,
	TempoMinimo TIME NOT NULL,
	TempoMaximo TIME NOT NULL,
	ValorMinimo DECIMAL(6,2),
	ValorMaximo DECIMAL(6,2),
	PRIMARY KEY (idRegra));

-- DROP TABLE LEILUM.Categoria;
CREATE TABLE LEILUM.Categoria (
	idCategoria INT NOT NULL,
	Designacao VARCHAR(45) NOT NULL,
	Regras INT NOT NULL,
	FOREIGN KEY (Regras) REFERENCES LEILUM.Regra (idRegra),
	PRIMARY KEY (idCategoria));

-- DROP TABLE LEILUM.Leilao;
CREATE TABLE LEILUM.Leilao (
	idLeilao INT NOT NULL,
	Titulo VARCHAR(45) NOT NULL,
	Duracao TIME NOT NULL,
	ValorAbertura DECIMAL(6,2) NOT NULL,
	ValorBase DECIMAL(6,2) NOT NULL,
	ValorMinimo DECIMAL(6,2) NOT NULL,
	Estado INT NOT NULL,
	Avaliador VARCHAR(45) NOT NULL,
	Comitente VARCHAR(45) NOT NULL,
	Lote INT NOT NULL,
	Categoria INT NOT NULL,
	FOREIGN KEY (Avaliador) REFERENCES LEILUM.Utilizador (Email),
	FOREIGN KEY (Comitente) REFERENCES LEILUM.Utilizador (Email),
	FOREIGN KEY (Lote) REFERENCES LEILUM.Lote (idLote),
	FOREIGN KEY (Categoria) REFERENCES LEILUM.Categoria (idCategoria),
	PRIMARY KEY (idLeilao));

-- DROP TABLE LEILUM.Licitacao;
CREATE TABLE LEILUM.Licitacao (	
	idLicitacao INT NOT NULL,
	Valor DECIMAL(6,2) NOT NULL,
	Licitador VARCHAR(45) NOT NULL,
	Leilao INT NOT NULL,
	FOREIGN KEY (Licitador) REFERENCES LEILUM.Utilizador (Email),
	FOREIGN KEY (Leilao) REFERENCES LEILUM.Leilao (idLeilao),
	PRIMARY KEY (idLicitacao));

USE master;
GO