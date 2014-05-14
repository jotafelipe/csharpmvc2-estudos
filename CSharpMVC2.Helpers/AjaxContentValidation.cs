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

using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CSharpMVC2.Helpers {

    /// <summary>
    /// 
    /// </summary>
    public class AjaxContentValidation : IDisposable {
        private readonly MvcForm form;
        private readonly ViewContext viewContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewContext"></param>
        /// <param name="form"></param>
        public AjaxContentValidation(ViewContext viewContext,
                MvcForm form) {
            this.viewContext = viewContext;
            this.form = form;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            if (this.form != null) {
                this.viewContext.OutputClientValidation();
                this.viewContext.FormContext = null;
            }
        }
    }
}