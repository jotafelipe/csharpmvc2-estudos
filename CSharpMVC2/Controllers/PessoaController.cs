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
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using CSharpMVC2.Helpers;
using CSharpMVC2.Model;
using CSharpMVC2.Util;
using NHibernate;
using NHibernate.Criterion;
using System.Data.SqlClient;
using NHibernate.Exceptions;

namespace CSharpMVC2.Controllers {

    /// <summary>
    ///
    /// </summary>
    [HandleError]
    public class PessoaController: Controller {
        public static IEnumerable<SelectListItem> Empresas;
        public static IEnumerable<SelectListItem> TipoTelefones;

        /// <summary>
        ///
        /// </summary>
        public PessoaController()
            : base() {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTelefone() {
            return PartialView("EditorTemplates/Telefones", new Telefone());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id) {
            using(ISession session = NHibernateHelper.OpenSession()) {
                using(ITransaction transaction = session.BeginTransaction()) {
                    Pessoa obj = session.CreateCriteria<Pessoa>()
                            .Add(Restrictions.Eq(Pessoa.ID, id))
                            .UniqueResult<Pessoa>();
                    try {
                        session.Delete(obj);
                        transaction.Commit();
                        ViewData[Constantes.VD_MSG_SUCESSO] =
                                Constantes.MSG_SUCESSO_EXCLUIDO;
                    } catch(Exception) {
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
            Pessoa obj = new Pessoa();
            if(id > 0) {
                obj = NHibernateHelper.OpenSession().CreateCriteria<Pessoa>()
                    .Add(Restrictions.Eq(Projections.Property(Pessoa.ID), id))
                    .UniqueResult<Pessoa>();
            }
            return View("Edit", obj);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Pessoa obj) {
            using(ISession session = NHibernateHelper.OpenSession()) {
                using(ITransaction transaction = session.BeginTransaction()) {
                    try {
                        foreach(Telefone tel in obj.Telefones) {
                            tel.Pessoa = obj;
                        }
                        session.Merge(obj);
                        transaction.Commit();
                        ViewData[Constantes.VD_MSG_SUCESSO] =
                            Constantes.MSG_SUCESSO_REGISTRO_ATUALIZADO;
                    } catch(PropertyValueException) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_REGISTRO_ATUALIZADO;
                        transaction.Rollback();
                    } catch(SqlException se) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_REGISTRO_ATUALIZADO
                                + @" :: " + se.Message;
                        transaction.Rollback();
                    } catch(GenericADOException ge) {
                        ViewData[Constantes.VD_MSG_ERRO] =
                                Constantes.MSG_ERRO_REGISTRO_ATUALIZADO
                                + @" :: " + (ge.InnerException != null ?
                                    ge.InnerException.Message : ge.Message);
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
            IList<Pessoa> lista = new List<Pessoa>();
            string busca = Request.Params[Constantes.IX_FORM_TEXTO_BUSCA];
            if(busca != null && !busca.Equals("")) {
                ICriteria criteria = NHibernateHelper.OpenSession()
                        .CreateCriteria<Pessoa>();
                Disjunction nomeOrSobrenome = Restrictions.Disjunction();
                nomeOrSobrenome.Add(Restrictions.Like(Pessoa.NOME, busca,
                       MatchMode.Anywhere).IgnoreCase());
                nomeOrSobrenome.Add(Restrictions.Like(Pessoa.SOBRENOME, busca,
                       MatchMode.Anywhere).IgnoreCase());
                criteria.Add(nomeOrSobrenome);
                if(!Request.Params[Constantes.IX_FORM_MOSTRAR_INATIVOS]
                        .Contains("true")) {
                    criteria.Add(Restrictions.Eq(Pessoa.IS_ATIVO, true));
                }
                lista = criteria.List<Pessoa>();
            }
            return View("Index", lista);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);
            Empresas = NHibernateHelper.OpenSession()
                .CreateCriteria<Empresa>()
                .Add(Restrictions.Eq(Empresa.IS_ATIVO, true))
                .AddOrder(Order.Asc(Empresa.DESCRICAO))
                .List<Empresa>()
                .Select(o => new SelectListItem() {
                    Text = o.Descricao,
                    Value = o.Id.ToString()
                })
                .ToList<SelectListItem>();
            TipoTelefones = NHibernateHelper.OpenSession()
                .CreateCriteria<TipoTelefone>()
                .Add(Restrictions.Eq(TipoTelefone.IS_ATIVO, true))
                .AddOrder(Order.Asc(TipoTelefone.DESCRICAO))
                .List<TipoTelefone>()
                .Select(o => new SelectListItem() {
                    Text = o.Descricao,
                    Value = o.Id.ToString()
                })
                .ToList<SelectListItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet]
        public bool VerificarCpf(string cpf) {
            if(String.IsNullOrEmpty(cpf)) {
                return false;
            }
            cpf = Utils.RemoveCaracteresEspeciais(cpf);
            return Utils.IsCpfValido(cpf) ?
                NHibernateHelper.OpenSession()
                    .CreateCriteria<Pessoa>()
                    .Add(Restrictions.Eq(Pessoa.CPF, cpf))
                    .UniqueResult<Pessoa>() == null
                : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public bool VerificarEmail(string email) {
            if(String.IsNullOrEmpty(email)) {
                return false;
            }
            return Utils.IsEmailValido(email) ?
                NHibernateHelper.OpenSession()
                    .CreateCriteria<Pessoa>()
                    .Add(Restrictions.Eq(Pessoa.EMAIL, email))
                    .UniqueResult<Pessoa>() == null
                : false;
        }
    }
}