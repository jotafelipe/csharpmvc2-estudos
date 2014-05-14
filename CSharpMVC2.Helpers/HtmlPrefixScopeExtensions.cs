/*
 * Propriedade de Juliano Andr� Felipe.
 *
 * Esse software � informa��o p�blica e gr�tis para fins n�o comerciais.
 *
 * Voc� n�o deve se basear nesse material para aprender qualquer uma das
 * t�cnicas ou linguagens de programa��o aqui apresentadas. Esse c�digo-fonte
 * serve apenas para meus estudos pessoais e/ou exemplos de t�cnicas que
 * utilizo, ou ainda como base de conhecimento pessoal p�blica.
 *
 * Esse N�O � um software comercial, utiliz�vel ou qualquer outra coisa que
 * voc� queira imaginar e depois vir me cobrar alguma coisa.
 *
 * Nenhum propriet�rio garante que qualquer c�digo-fonte, software ou t�cnica
 * utilizada aqui funcione de qualquer maneira.
 *
 * � proibido vender ou utilizar esse software para fins comerciais. Contudo,
 * voc� pode tomar os c�digos-fontes aqui apresentados como exemplo, para fins
 * comerciais ou n�o.
 *
 * O(s) propriet�rio(s) desse software N�O SE RESPONSABILIZA(M) DE MANEIRA
 * NENHUMA por qualquer uso que se fa�a dele. N�o � obriga��o de nenhum
 * propriet�rio garantir que esse software funcione e/ou seja "bug-free".
 *
 *
 * ****************************************************************************
 *
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CSharpMVC2.Helpers {

    /// <summary>
    ///
    /// </summary>
    public static class HtmlPrefixScopeExtensions {

        /// <summary>
        ///
        /// </summary>
        private const string idsToReuseKey =
                "__htmlPrefixScopeExtensions_IdsToReuse_";

        /// <summary>
        ///
        /// </summary>
        /// <param name="html"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static IDisposable BeginCollectionItem(this HtmlHelper html,
                string collectionName) {
            var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext,
                    collectionName);
            string itemIndex = idsToReuse.Count > 0 ?
                    idsToReuse.Dequeue()
                  : Guid.NewGuid().ToString();
            // autocomplete="off" is needed to work around a very annoying
            // Chrome behaviour whereby it reuses old values after the user
            // clicks "Back", which causes the xyz.index and xyz[...] values to
            // get out of sync.
            html.ViewContext.Writer.WriteLine(
                string.Format("<input type=\"hidden\" name=\"{0}.index\" "
                        + " autocomplete=\"off\" value=\"{1}\" />",
                    collectionName, html.Encode(itemIndex)));
            return BeginHtmlFieldPrefixScope(html, string.Format("{0}[{1}]",
                    collectionName, itemIndex));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlFieldPrefix"></param>
        /// <returns></returns>
        public static IDisposable BeginHtmlFieldPrefixScope(
                this HtmlHelper html, string htmlFieldPrefix) {
            return new HtmlFieldPrefixScope(html.ViewData.TemplateInfo,
                    htmlFieldPrefix);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        private static Queue<string> GetIdsToReuse(HttpContextBase httpContext,
                string collectionName) {
            // We need to use the same sequence of IDs following a server-side
            // validation failure,  otherwise the framework won't render the
            // validation error messages next to each item.
            string key = idsToReuseKey + collectionName;
            var queue = (Queue<string>)httpContext.Items[key];
            if (queue == null) {
                httpContext.Items[key] = queue = new Queue<string>();
                var previouslyUsedIds =
                        httpContext.Request[collectionName + ".index"];
                if (!string.IsNullOrEmpty(previouslyUsedIds))
                    foreach (string previouslyUsedId
                            in previouslyUsedIds.Split(','))
                        queue.Enqueue(previouslyUsedId);
            }
            return queue;
        }
    }
}