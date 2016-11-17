using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Validation
{
    /// <summary>
    /// Classe responsável por validações básicas da página de cadastro de cartão
    /// </summary>
    public class CardValidation
    {
        /// <summary>
        /// Verifica se algum campo foi enviado em branco
        /// </summary>
        /// <param name="name">Nome do cliente no cartão</param>
        /// <param name="Number">Número do cartão</param>
        /// <param name="ExpirationDate">Data de validade do cartão</param>
        /// <param name="CardBrand">bandeira do cartão</param>
        /// <param name="Password">Senha do cartão</param>
        /// <param name="Type">Tipo do cartão - Chip ou Tarja Magnética</param>
        /// <param name="idClient">Cliente associado ao cartão</param>
        public static void Validation(string name, string Number, string ExpirationDate, string CardBrand, string Type, int idClient)
        {
            if (string.IsNullOrWhiteSpace(name) || 
                    string.IsNullOrWhiteSpace(Number) || 
                        string.IsNullOrWhiteSpace(ExpirationDate) || 
                             string.IsNullOrWhiteSpace(CardBrand) ||  
                                string.IsNullOrWhiteSpace(Type) ||
                                    idClient < 1)
            {
                throw new Exception("Favor preencher todo o formulário");
            }
        }      
    }
}
