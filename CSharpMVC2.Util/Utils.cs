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
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpMVC2.Util {

    public class Utils {

        /// <summary>
        /// Higieniza a string passada por parâmetro, trocando os caracteres
        /// especiais por seus equivalentes em unicode.
        /// </summary>
        /// <param name="text">string a ser higienizada</param>
        /// <returns>string com os caracteres especiais trocados por seus
        /// euivalentes em unicode</returns>
        public static string RemoveCaracteresEspeciais(string text) {
            if(text == null) {
                throw new ArgumentNullException("text");
            }
            if(text.Length > 0) {
                char[] chars = new char[text.Length];
                int charIndex = 0;
                text = text.Normalize(NormalizationForm.FormD);
                for(int i = 0; i < text.Length; i++) {
                    char c = text[i];
                    if(CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory
                            .NonSpacingMark) {
                        chars[charIndex++] = c;
                    }
                }
                return new string(chars, 0, charIndex).Normalize(
                        NormalizationForm.FormC);
            }
            return text;
        }

        /// <summary>
        /// Valida o cpf passado por parâmetro
        /// </summary>
        /// <param name="cpf">cpf a ser validado</param>
        /// <returns>bool</returns>
        public static bool IsCpfValido(string cpf) {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string cpfAux;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if(cpf.Length != 11) {
                return false;
            }
            cpfAux = cpf.Substring(0, 9);
            soma = 0;
            for(int i = 0; i < 9; i++) {
                soma += int.Parse(cpfAux[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if(resto < 2) {
                resto = 0;
            } else {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            cpfAux = cpfAux + digito;
            soma = 0;
            for(int i = 0; i < 10; i++) {
                soma += Int32.Parse(cpfAux[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if(resto < 2) {
                resto = 0;
            } else {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Valida o Email passado por parâmetro
        /// </summary>
        /// <param name="email">Email a ser validado</param>
        /// <returns>bool</returns>
        public static bool IsEmailValido(string email) {
            return new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))"
                    + @"|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))"
                    + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*"
                    + @"[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
                .IsMatch(email);
        }
    }
}