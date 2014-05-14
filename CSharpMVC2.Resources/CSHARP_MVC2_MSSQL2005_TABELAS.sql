/*
 * Propriedade de Juliano André Felipe.
 *
 * Esse software é informação pública e grátis para fins não comerciais.
 * 
 * Você não deve se basear nesse material para aprender qualquer uma das 
 * técnicas ou linguagens de programação aqui apresentadas. Esse código-fonte 
 * serve apenas para meus estudos pessoais e/ou exemplos de técnicas que 
 * utilizo, ou ainda como base de conhecimento pessoal pública.
 * 
 * Esse NÃO é um software comercial, utilizável ou qualquer outra coisa que 
 * você queira imaginar e depois vir me cobrar alguma coisa.
 * 
 * Nenhum proprietário garante que qualquer código-fonte, software ou técnica
 * utilizada aqui funcione de qualquer maneira.
 *
 * É proibido vender ou utilizar esse software para fins comerciais. Contudo,
 * você pode tomar os códigos-fontes aqui apresentados como exemplo, para fins
 * comerciais ou não.
 *
 * O(s) proprietário(s) desse software NÃO SE RESPONSABILIZA(M) DE MANEIRA
 * NENHUMA por qualquer uso que se faça dele. Não é obrigação de nenhum 
 * proprietário garantir que esse software funcione e/ou seja "bug-free".
 *
 * 
 * ****************************************************************************
 * Ordem correta para executar os arquivos da aplicação:
 *
 * 1. CSHARP_MVC2_MSSQL2005_TABELAS.sql
 * 2. Testes
 * 3. CSHARP_MVC2_MSSQL2005_RESEED_TABELAS.sql
 * 4. CSHARP_MVC2_MSSQ2005_REGISTROS_DEFAULT.sql
 */

V1_0_0:
criacao_base:
-- Server: db2
USE [MASTER]
GO
IF DB_ID(N'CSHARP_MVC2') IS NOT NULL BEGIN
    DROP DATABASE CSHARP_MVC2;
END
GO
CREATE DATABASE CSHARP_MVC2
ALTER DATABASE [CSHARP_MVC2] MODIFY FILE (
    NAME = N'CSHARP_MVC2' 
  , SIZE = 5MB
  , MAXSIZE = 10MB
  , FILEGROWTH = 100KB
)
ALTER DATABASE [CSHARP_MVC2] MODIFY FILE (
    NAME = N'CSHARP_MVC2_LOG'
  , SIZE = 5MB
  , MAXSIZE = 10MB
  , FILEGROWTH = 1%
)
ALTER DATABASE CSHARP_MVC2 COLLATE SQL_Latin1_General_CP1_CI_AS;
ALTER DATABASE CSHARP_MVC2 SET RECOVERY SIMPLE;
GO
USE [CSHARP_MVC2]
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'AUTOCLOSE', N'FALSE'
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'AUTO CREATE STATISTICS', N'TRUE'
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'AUTOSHRINK', N'FALSE'
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'AUTO UPDATE STATISTICS', N'TRUE'
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'QUOTED IDENTIFIER', N'FALSE'
GO
EXEC SP_DBOPTION N'CSHARP_MVC2', N'ANSI WARNINGS', N'FALSE'
GO
-- ----------------------------------------------------------------------------
core:
USE [CSHARP_MVC2]
GO
CREATE TABLE DBO.CM_TB_EMPRESA (
    [ID] INT IDENTITY PRIMARY KEY
  , [DESCRICAO] VARCHAR(300) NOT NULL
  , [IS_ATIVO] BIT DEFAULT 1
)
ALTER TABLE DBO.CM_TB_EMPRESA ADD CONSTRAINT
    UQ_EMPRESA_DESCRICAO UNIQUE NONCLUSTERED(DESCRICAO)
GO
CREATE TABLE DBO.CM_TB_PESSOA (
    [ID] INT IDENTITY PRIMARY KEY
  , [CPF] VARCHAR(20) NOT NULL
  , [NOME] VARCHAR(100) NOT NULL
  , [SOBRENOME] VARCHAR(100) NOT NULL
  , [EMAIL] VARCHAR(256)
  , [CEP] VARCHAR(10)
  , [DATA_NASCIMENTO] DATETIME
  , [SALARIO] DECIMAL(23,2)
  , [ID_EMPRESA] INT REFERENCES DBO.CM_TB_EMPRESA(ID) NULL
  , [IS_ATIVO] BIT DEFAULT 1
)
ALTER TABLE DBO.CM_TB_PESSOA ADD CONSTRAINT
    UQ_PESSOA_CPF UNIQUE NONCLUSTERED(CPF)
ALTER TABLE DBO.CM_TB_PESSOA ADD CONSTRAINT
    UQ_PESSOA_EMAIL UNIQUE NONCLUSTERED(EMAIL)
GO
CREATE TABLE DBO.CM_TB_TIPO_TELEFONE (
    [ID] INT IDENTITY PRIMARY KEY
  , [DESCRICAO] VARCHAR(30) NOT NULL
  , [IS_ATIVO] BIT DEFAULT 1
)
ALTER TABLE DBO.CM_TB_TIPO_TELEFONE ADD CONSTRAINT
    UQ_TIPO_TELEFONE_DESCRICAO UNIQUE NONCLUSTERED(DESCRICAO)
GO
CREATE TABLE DBO.CM_TB_TELEFONE (
    [ID] INT IDENTITY PRIMARY KEY
  , [DDD] INT NOT NULL
  , [FONE] VARCHAR(10) NOT NULL
  , [ID_TIPO_TELEFONE] INT REFERENCES CM_TB_TIPO_TELEFONE(ID) NOT NULL
  , [ID_PESSOA] INT REFERENCES CM_TB_PESSOA(ID) NOT NULL
  , [IS_ATIVO] BIT DEFAULT 1
)
ALTER TABLE DBO.CM_TB_TELEFONE ADD CONSTRAINT
    UQ_TELEFONE_DDD_FONE UNIQUE NONCLUSTERED(DDD, FONE)
GO
-- -----------------------------------------------------------------------------
