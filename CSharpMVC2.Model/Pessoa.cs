/*
 * Propriedade de Juliano André Felipe.
 *
 * Esse software é informação pública e grátis para fins não comerciais.
 *
 * Você não deve se basear nesse material para aprender qualquer uma das
 * técnicas ou linguagens de programação aqui apresentadas. Esse código-fonte
 * serve apenas para meus estudos pessoais e/ou exemplos de técnicas que
 * utilizo, ou ainda como base de conhecimento pessoal-pública.
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSharpMVC2.Model {

    /// <summary>
    ///
    /// </summary>
    public class Pessoa {
        public static readonly string ALIAS_CLASSE = "Pessoa";

        public static readonly string CEP = "Cep";
        public static readonly string CPF = "Cpf";
        public static readonly string DATA_NASCIMENTO = "DataNascimento";
        public static readonly string EMAIL = "Email";
        public static readonly string EMPRESA = "Empresa";
        public static readonly string ID = "Id";
        public static readonly string IS_ATIVO = "IsAtivo";
        public static readonly string NOME = "Nome";
        public static readonly string SALARIO = "Salario";
        public static readonly string SOBRENOME = "Sobrenome";

        /// <summary>
        ///
        /// </summary>
        public Pessoa() {
            this.IsAtivo = true;
            Telefones = new List<Telefone>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        public Pessoa(int id) {
            Id = id;
            this.IsAtivo = true;
            Telefones = new List<Telefone>();
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("CEP:")]
        public virtual String Cep {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("CPF:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String Cpf {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Data de Nascimento:")]
        public virtual DateTime? DataNascimento {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Email:")]
        [RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b",
                ErrorMessage = "Email inválido")]
        public virtual String Email {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Empresa:")]
        public virtual Empresa Empresa {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Código:")]
        public virtual int Id {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Ativo:")]
        public virtual bool IsAtivo {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Nome:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String Nome {
            get;
            set;
        }

        // Propriedades Transientes
        /// <summary>
        ///
        /// </summary>
        public virtual String T_NomeCompleto {
            get {
                return this.Nome + @" " + this.Sobrenome;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Salário:")]
        public virtual Double Salario {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DisplayName("Sobrenome:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual String Sobrenome {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        public virtual IList<Telefone> Telefones {
            get;
            set;
        }

        /// <summary>
        /// Sobreescreve o operador != (diferente)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Pessoa a, Pessoa b) {
            return !(a == b);
        }

        /// <summary>
        /// Sobreescreve o operador == (igual) (* não operador identico)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Pessoa a, Pessoa b) {
            if (Object.ReferenceEquals(a, b)) {
                return true;
            }
            if (((object)a == null) || ((object)b == null)) {
                return false;
            }
            return a.Id == b.Id;
        }

        /// <summary>
        /// Cria uma cópia superficial do Objeto
        /// </summary>
        /// <returns></returns>
        public virtual Pessoa Clone() {
            return (Pessoa)MemberwiseClone();
        }

        /// <summary>
        /// sobreescreve o método Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <b>true</b> se o objeto é igual ao parâmetro
        /// <b>false</b> caso contrário
        /// </returns>
        public override bool Equals(Object obj) {
            if (obj == null) {
                return false;
            }
            Pessoa o = obj as Pessoa;
            if ((Object)o == null) {
                return false;
            }
            return (Id == o.Id);
        }

        /// <summary>
        /// Sobreescreve o método GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode() ^ Id;
        }

        // <summary>
        /// Sobreescreve o método <code>ToString()</code> da classe base
        /// <code>Object</code>, retornando uma descrição breve do objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return String.Format(this.GetType().FullName + "[ID: {0:n},"
                + " Description: {1:s} {2:s}]", this.Id, this.Nome,
                this.Sobrenome);
        }
    }
}