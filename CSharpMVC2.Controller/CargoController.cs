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

namespace Cadu.Controllers {

    /// <summary>
    ///
    /// </summary>
    [HandleError]
    public class CargoController : Controller {

        /// <summary>
        ///
        /// </summary>
        public CargoController()
            : base() {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create() {
            return View("Create");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Cargo obj) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    try {
                        session.Merge(obj);
                        transaction.Commit();
                        ViewData[Constantes.VD_MSG_SUCESSO] =
                                Constantes.MSG_SUCESSO_REGISTRO_SALVO;
                    } catch (PropertyValueException) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_REGISTRO_SALVO;
                        transaction.Rollback();
                    }
                }
            }
            return View("Create", obj);
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
                    Cargo obj = session.CreateCriteria<Cargo>()
                            .Add(Restrictions.Eq(Cargo.ID, id))
                            .UniqueResult<Cargo>();
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
            return this.Index();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Detail(int id) {
            Cargo obj = NHibernateHelper.OpenSession().CreateCriteria<Cargo>()
                .Add(Restrictions.Eq(Projections.Property(Cargo.ID), id))
                .UniqueResult<Cargo>();
            return View("Detail", obj);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id) {
            Cargo obj = NHibernateHelper.OpenSession().CreateCriteria<Cargo>()
                .Add(Restrictions.Eq(Projections.Property(Cargo.ID), id))
                .UniqueResult<Cargo>();
            return View("Edit", obj);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Cargo obj) {
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
        public ActionResult Index(int page = 0) {
            int firstResult = Util.CalculaPaginacao(page);
            IList<Cargo> lista = NHibernateHelper.OpenSession()
                .CreateCriteria<Cargo>()
                .SetFirstResult(firstResult)
                .SetMaxResults(Constantes.MISC_MAX_RESULTADOS_PAGINA)
                .List<Cargo>();
            ViewData[Constantes.SS_TOTAL_PAGINAS] =
                    Session[Constantes.SS_TOTAL_PAGINAS];
            return View("Index", lista);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);
            if (Session[Constantes.SS_TOTAL_PAGINAS] == null) {
                Session[Constantes.SS_TOTAL_PAGINAS] = NHibernateHelper
                        .OpenSession()
                        .CreateCriteria<Cargo>()
                        .Add(Restrictions.Eq(Cargo.IS_ATIVO, true))
                        .SetProjection(Projections.Count(Cargo.ID))
                        .UniqueResult<int>() / Constantes
                                .MISC_MAX_RESULTADOS_PAGINA;
            }
            ViewData[Constantes.SS_TOTAL_PAGINAS] =
                    Session[Constantes.SS_TOTAL_PAGINAS];
        }
    }
}