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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CSharpMVC2.Model {

    /// <summary>
    /// 
    /// </summary>
    public class Telefone {
        public static readonly string ALIAS_CLASSE = "Telefone";

        public static readonly string ID = "Id";
        public static readonly string DDD = "Ddd";
        public static readonly string FONE = "Fone";
        public static readonly string PESSOA = "Pessoa";
        public static readonly string TIPO_TELEFONE = "TipoTelefone";
        public static readonly string IS_ATIVO = "IsAtivo";

        /// <summary>
        /// 
        /// </summary>
        public Telefone() {
            this.IsAtivo = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Telefone(int id) {
            Id = id;
            this.IsAtivo = true;
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
        [DisplayName("DDD:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(0, 99, ErrorMessage = "O DDD deve conter dois caracteres")]
        public virtual int Ddd {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Fone:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [RegularExpression(@"^.{8,9}$",
                ErrorMessage = "O telefone deve conter 8 ou 9 caracteres")]
        public virtual string Fone {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Pessoa:")]
        public virtual Pessoa Pessoa {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Tipo de Telefone:")]
        [Required(ErrorMessage = "O telefone deve ter um Tipo")]
        public virtual TipoTelefone TipoTelefone {
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
        /// sobreescreve o método Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <b>true</b> se o objeto é igual ao parâmetro
        /// <b>false</b> caso contrário
        /// </returns>
        public override bool Equals(Object obj) {
            if(obj == null) {
                return false;
            }
            Telefone o = obj as Telefone;
            if((Object) o == null) {
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

        /// <summary>
        /// Sobreescreve o operador == (igual) (* não operador identico)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Telefone a, Telefone b) {
            if(Object.ReferenceEquals(a, b)) {
                return true;
            }
            if(((object) a == null) || ((object) b == null)) {
                return false;
            }
            return a.Id == b.Id && a.Ddd == b.Ddd && a.Fone == b.Fone;
        }

        /// <summary>
        /// Sobreescreve o operador != (diferente)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Telefone a, Telefone b) {
            return !(a == b);
        }

        /// <summary>
        /// Cria uma cópia superficial do Objeto
        /// </summary>
        /// <returns></returns>
        public virtual Telefone Clone() {
            return (Telefone) MemberwiseClone();
        }

        // <summary>
        /// Sobreescreve o método <code>ToString()</code> da classe base
        /// <code>Object</code>, retornando uma descrição breve do objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return String.Format(this.GetType().FullName + "[ID: {0:n},"
                + " Description: {1:s}]", this.Id,
                this.Ddd.ToString() + this.Fone);
        }
    }
}