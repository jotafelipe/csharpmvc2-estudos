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
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using CSharpMVC2.Helpers;
using CSharpMVC2.Model;
using CSharpMVC2.Util;
using NHibernate;
using NHibernate.Criterion;

namespace CSharpMVC2.Controllers {

    /// <summary>
    ///
    /// </summary>
    [HandleError]
    public class TelefoneController : Controller {

        /// <summary>
        ///
        /// </summary>
        public TelefoneController()
            : base() {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    Telefone obj = session.CreateCriteria<Telefone>()
                            .Add(Restrictions.Eq(Telefone.ID, id))
                            .UniqueResult<Telefone>();
                    try {
                        session.Delete(obj);
                        transaction.Commit();
                        ViewData[Constantes.VD_MSG_SUCESSO] =
                                Constantes.MSG_SUCESSO_EXCLUIDO;
                    } catch (Exception) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_EXCLUIDO;
                        transaction.Rollback();
                    }
                }
            }
            return this.Index(null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id) {
            Telefone obj = new Telefone();
            if (id > 0) {
                obj = NHibernateHelper.OpenSession().CreateCriteria<Telefone>()
                    .Add(Restrictions.Eq(Projections.Property(Telefone.ID), id))
                    .UniqueResult<Telefone>();
            }
            return View("Edit", obj);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Telefone obj) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    try {
                        session.Merge(obj);
                        transaction.Commit();
                        ViewData[Constantes.VD_MSG_SUCESSO] =
                            Constantes.MSG_SUCESSO_REGISTRO_ATUALIZADO;
                    } catch (PropertyValueException) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_REGISTRO_ATUALIZADO;
                        transaction.Rollback();
                    }
                }
            }
            return View("Edit", obj);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(FormCollection formValues, int page = 0) {
            IList<Telefone> lista = new List<Telefone>();
            string busca = Request.Params[Constantes.IX_FORM_TEXTO_BUSCA];
            if (busca != null && !busca.Equals("")) {
                ICriteria criteria = NHibernateHelper.OpenSession()
                        .CreateCriteria<Telefone>();
                Disjunction dddOrFone = Restrictions.Disjunction();
                dddOrFone.Add(Restrictions.Like(Telefone.DDD, busca,
                       MatchMode.Anywhere).IgnoreCase());
                dddOrFone.Add(Restrictions.Like(Telefone.FONE, busca,
                       MatchMode.Anywhere).IgnoreCase());
                criteria.Add(dddOrFone);
                if (!Request.Params[Constantes.IX_FORM_MOSTRAR_INATIVOS]
                        .Contains("true")) {
                    criteria.Add(Restrictions.Eq(Telefone.IS_ATIVO, true));
                }
                lista = criteria.List<Telefone>();
            }
            return View("Index", lista);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);

        }
    }
}