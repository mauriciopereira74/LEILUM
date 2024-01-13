USE master;
GO

-- Criação do login no nível da instancia do SQL SERVER
CREATE LOGIN leilum WITH PASSWORD = 'leilum', CHECK_POLICY = OFF;

USE LEILUM;
GO

-- Criação do user ao nível da BD LEILUM
USE LEILUM;
CREATE USER leilum FOR LOGIN leilum;

-- Adicao de permissões ao user LEILUM.
ALTER ROLE db_owner ADD MEMBER leilum;