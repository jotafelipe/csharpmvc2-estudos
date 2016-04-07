  ﻿/*
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

-- INSERT INTO DBO.CM_TB_() VALUES()
v1_0_0:
INSERT INTO DBO.CM_TB_EMPRESA(DESCRICAO, IS_ATIVO) VALUES('T.I.',                  1)
INSERT INTO DBO.CM_TB_EMPRESA(DESCRICAO, IS_ATIVO) VALUES('Engenharia',            1)
INSERT INTO DBO.CM_TB_EMPRESA(DESCRICAO, IS_ATIVO) VALUES('RH',                    1)
INSERT INTO DBO.CM_TB_EMPRESA(DESCRICAO, IS_ATIVO) VALUES('Negócios Imobiliários', 1)
GO
INSERT INTO DBO.CM_TB_TIPO_TELEFONE(DESCRICAO, IS_ATIVO) VALUES('Celular',     1)
INSERT INTO DBO.CM_TB_TIPO_TELEFONE(DESCRICAO, IS_ATIVO) VALUES('Comercial',   1)
INSERT INTO DBO.CM_TB_TIPO_TELEFONE(DESCRICAO, IS_ATIVO) VALUES('Residencial', 1)
GO
/* ************************************************************************* */
