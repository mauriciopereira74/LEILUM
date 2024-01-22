USE master;
GO

CREATE DATABASE LEILUM;
GO

USE LEILUM;
GO


-- DROP TABLE TipoUtilizador
CREATE TABLE TipoUtilizador (
	Tipo INT NOT NULL,
	Role VARCHAR(45) NOT NULL,
	PRIMARY KEY (Tipo)
	);

-- DROP TABLE Utilizador;
CREATE TABLE Utilizador (
	Email VARCHAR(45) NOT NULL,
	Password VARCHAR(45) NOT NULL,
	TipoUtilizador INT NOT NULL,
	FOREIGN KEY (TipoUtilizador) REFERENCES TIPOUTILIZADOR (Tipo),
	PRIMARY KEY (Email)
);

-- DROP TABLE InfoUtilizador;
CREATE TABLE InfoUtilizador (
	Contribuinte INT NOT NULL,
	Nome VARCHAR(45) NOT NULL,
	Morada VARCHAR(100) NOT NULL,
	Nacionalidade VARCHAR(45) NOT NULL,
	Contacto VARCHAR(45) NOT NULL,
	DataNascimento DATE NOT NULL,
	MetodoPagamento INT NOT NULL,
	Iban VARCHAR(45) NOT NULL,
	FotoPerfilPath VARCHAR(500) NOT NULL,
	idUtilizador VARCHAR(45) NOT NULL,
	FOREIGN KEY (idUtilizador) REFERENCES Utilizador (Email),
	PRIMARY KEY (Contribuinte));

-- DROP TABLE Lote;
CREATE TABLE Lote (
	idLote INT NOT NULL,
	Comitente VARCHAR(45) NOT NULL,
	Comprador VARCHAR(45) NULL,
	Avaliador VARCHAR(45) NULL,
	FOREIGN KEY (Comitente) REFERENCES Utilizador (Email),
	FOREIGN KEY (Comprador) REFERENCES Utilizador (Email),
	FOREIGN KEY (Avaliador) REFERENCES Utilizador (Email),
	PRIMARY KEY (idLote));
	
-- DROP TABLE Artigo;
CREATE TABLE Artigo (
	idArtigo INT NOT NULL,
	Designacao VARCHAR(45) NOT NULL,
	Caracteristicas TEXT NOT NULL,
	Descricao TEXT NOT NULL,
	idLote INT NOT NULL,
	FOREIGN KEY (idLote) REFERENCES Lote (idLote),
	PRIMARY KEY (idArtigo));

-- DROP TABLE Regra;
CREATE TABLE Regra (
	idRegra INT NOT NULL,
	ValorMinimo DECIMAL(6,2),
	ValorMaximo DECIMAL(6,2),
	PRIMARY KEY (idRegra));

-- DROP TABLE Categoria;
CREATE TABLE Categoria (
	idCategoria INT NOT NULL,
	Designacao VARCHAR(45) NOT NULL,
	Regra INT NOT NULL,
	FOREIGN KEY (Regra) REFERENCES Regra (idRegra),
	PRIMARY KEY (idCategoria));

-- DROP TABLE Leilao;
CREATE TABLE Leilao (
	idLeilao INT NOT NULL,
	Titulo VARCHAR(45) NOT NULL,
	DataFim DATETIME NOT NULL,
	ValorAbertura DECIMAL(6,2) NULL, -- 50% do valor base do leilão
	ValorBase DECIMAL(6,2) NULL, -- Valor da Avaliação do leilão
	ValorMinimo DECIMAL(6,2) NOT NULL, -- Valor mais baixo pelo qual poderá licitar, corresponde a 85% do valor base. Se o valor de uma licitação estiver entre o valor de abertura e o valor minimo, então é considerado licitação condicional
	ValorAtual DECIMAL(6,2) NOT NULL, -- Valor da licitação mais alta
	Estado INT NOT NULL,
	Avaliador VARCHAR(45) NULL,
	Comitente VARCHAR(45) NOT NULL,
	Lote INT NOT NULL,
	Categoria INT NOT NULL,
	FOREIGN KEY (Avaliador) REFERENCES Utilizador (Email),
	FOREIGN KEY (Comitente) REFERENCES Utilizador (Email),
	FOREIGN KEY (Lote) REFERENCES Lote (idLote),
	FOREIGN KEY (Categoria) REFERENCES Categoria (idCategoria),
	PRIMARY KEY (idLeilao));

-- DROP TABLE Licitacao;
CREATE TABLE Licitacao (
	idLicitacao INT NOT NULL,
	Valor DECIMAL(6,2) NOT NULL,
	Licitador VARCHAR(45) NOT NULL,
	Leilao INT NOT NULL,
	FOREIGN KEY (Licitador) REFERENCES Utilizador (Email),
	FOREIGN KEY (Leilao) REFERENCES Leilao (idLeilao),
	PRIMARY KEY (idLicitacao));

CREATE TABLE Avaliador (
	Avaliador VARCHAR(45) NOT NULL,
	Categoria INT NOT NULL,
	FOREIGN KEY (Avaliador) REFERENCES Utilizador (Email),
	FOREIGN KEY (Categoria) REFERENCES Categoria (idCategoria)
);

USE master;
GO