# README

**Por favor, tenha em mente que este projeto é apenas para estudo.**<br/>
**Nem tudo nele estará funcionando 100%.**

Esse material é informação **pública** e grátis.

Você **não** deve se basear nesse material para aprender qualquer uma das
técnicas ou linguagens de programação aqui apresentadas. Esse código-fonte
serve apenas para meus estudos pessoais e/ou exemplos de técnicas que
utilizo, ou ainda como base de conhecimento pessoal acessível ao público.

Esse **NÃO** é um software comercial, utilizável ou qualquer outra coisa que
você queira imaginar e depois vir me cobrar alguma coisa. O material aqui 
apresentado serve apenas como meus estudos pessoais, como mencionado
anteriormente.

Nenhum proprietário garante que qualquer código-fonte, software ou técnica
utilizada aqui funcione de qualquer maneira.

É proibido vender ou utilizar esse software para fins comerciais. Contudo,
você pode tomar os códigos-fontes aqui apresentados como exemplo, para fins
comerciais ou não.

O(s) proprietário(s) desse material **NÃO SE RESPONSABILIZA(M) DE MANEIRA**
**NENHUMA** por qualquer uso que se faça dele. Não é obrigação de nenhum
proprietário garantir que esse software funcione e/ou seja "bug-free".

====

## Instruções para rodar o software:

1. Certifique-se que você tem o .NET Framework 3.5 instalado (Não foi testado com outras versões ainda);

2.  Crie o Banco de Dados e as tabelas rodando o conteúdo do arquivo no _Manager_ (prompt/Management Studio/sinal de fumaça) do SQL Server:
	`CSharpMVC2.Resources.CSHARP_MVC2_MSSQL2005_TABELAS.sql`;

3.  Opcional: Rode também o arquivo `CSharpMVC2.Resources.CSHARP_MVC2_MSSQ2005_REGISTROS_DEFAULT.sql`;

4. Crie um usuário e um login no SQL Server com o nome e senha ´testefelipe´, ou modifique o arquivo `CSharpMVC2.Resources.hibernate.cfg.xml` e insira o usuário e senha que você colocou no SQL Server;

5. Rode a aplicação pelo **Visual Studio 2010**, ou faça build e insira em algum IIS que rode o .NET3.5 e MVC2.

---- 

###### Juliano André Felipe - 2014