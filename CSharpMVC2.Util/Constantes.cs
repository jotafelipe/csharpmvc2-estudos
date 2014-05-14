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
 *
 *
 *
 */

namespace CSharpMVC2.Util {

    /// <summary>
    /// Classe com constantes utilizáveis na Aplicação toda.
    /// </summary>
    public class Constantes {
        // --------------------------------------------------------------------
        /* ##                   Aplicação                                 ## */

        /// <summary>
        /// Nome da Aplicação
        /// </summary>
        public const string APP_NAME = @"C# MVC2 Estudos";
        // --------------------------------------------------------------------
        /* ##                   Páginas Partial                           ## */

        /// <summary>
        /// Endereço da página (partial) de mensagens
        /// </summary>
        public const string PAGINA_MENSAGENS = "Mensagens";

        // --------------------------------------------------------------------
        /* ##                   Índices Session[]                         ## */

        /// <summary>
        /// Índice para o total de páginas nas listas em Session[]
        /// </summary>
        public const string SS_TOTAL_PAGINAS = "totalPages";

        /// <summary>
        /// Índice para a página atual nas listas em Session[]
        /// </summary>
        public const string SS_PAGINA_ATUAL = "currentPage";

        // --------------------------------------------------------------------
        /* ##                   Índices ViewData[]                        ## */

        /// <summary>
        /// Indice das mensagens de sucesso em ViewData[]
        /// </summary>
        public const string VD_MSG_SUCESSO = "successMessage";

        /// <summary>
        /// Indice das mensagens de erro em ViewData[]
        /// </summary>
        public const string VD_MSG_ERRO = "errorMessage";

        // --------------------------------------------------------------------
        /* ##                   Índices de campos de Formulário           ## */

        /// <summary>
        /// Indice do campo de busca por texto
        /// </summary>
        public const string IX_FORM_TEXTO_BUSCA = "txtBusca";

        /// <summary>
        /// Indice do combobox de Mostrar Inativos
        /// </summary>
        public const string IX_FORM_MOSTRAR_INATIVOS = "cbMostrarInativos";

        // --------------------------------------------------------------------
        /* ##                   Mensagens                                 ## */

        /// <summary>
        /// Retorna a mensagem "Registro salvo com sucesso"
        /// </summary>
        public const string MSG_SUCESSO_REGISTRO_SALVO = "Registro salvo com "
                + "sucesso";

        /// <summary>
        /// Retorna a mensagem "Erro ao salvar o registro"
        /// </summary>
        public const string MSG_ERRO_REGISTRO_SALVO = "Erro ao salvar o "
                + "registro";

        /// <summary>
        /// Retorna a mensagem "Registro atualizado com sucesso"
        /// </summary>
        public const string MSG_SUCESSO_REGISTRO_ATUALIZADO = "Registro "
                + "atualizado com sucesso";

        /// <summary>
        /// Retorna a mensagem "Erro ao atualizar o registro"
        /// </summary>
        public const string MSG_ERRO_REGISTRO_ATUALIZADO = "Erro ao atualizar "
                + "o registro";

        /// <summary>
        /// Retorna a mensagem "Registro excluído com sucesso"
        /// </summary>
        public const string MSG_SUCESSO_EXCLUIDO = "Registro excluído com "
                + "sucesso";

        /// <summary>
        /// Retorna a mensagem "Erro ao excluir o registro"
        /// </summary>
        public const string MSG_ERRO_EXCLUIDO = "Erro ao excluir o registro";

        /// <summary>
        /// Retorna a mensagem "Registros sincronizados com sucesso"
        /// </summary>
        public const string MSG_SUCESSO_SINCRONIZADO = "Registros "
                + "sincronizados com sucesso.";

        /// <summary>
        /// Retorna a mensagem "Registros sincronizados com sucesso"
        /// </summary>
        public const string MSG_ERRO_SINCRONIZADO = "Erro ao sincronizar os "
                + "registros";
        
        /// <summary>
        /// Retorna a mensagem "Erro ao realizar o upload do arquivo. Por 
        /// favor, tente novamente"
        /// </summary>
        public const string MSG_ERRO_UPLOAD_ARQUIVO = "Erro ao realizar o "
        + "upload do arquivo. Por favor, tente novamente";

        // --------------------------------------------------------------------
        /* ##                   Miscelânea                                ## */

        /// <summary>
        /// Máximo de registros em uma página das listas
        /// </summary>
        public const int MISC_MAX_RESULTADOS_PAGINA = 25;
    }
}