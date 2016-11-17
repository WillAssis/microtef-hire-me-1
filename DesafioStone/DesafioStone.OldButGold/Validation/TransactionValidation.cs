using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Validation
{
    /// <summary>
    /// Classe responsável por validações básicas da página de cadastro de transação
    /// </summary>
    public class TransactionValidation
    {
        /// <summary>
        /// Verifica se algum campo foi enviado em branco
        /// </summary>
        /// <param name="amount">Valor da transação</param>
        /// <param name="type">Tipo de transação - Débito ou crédito</param>
        /// <param name="number">Número de parcelas desejada</param>
        /// <param name="idClient">Id do cliente selecionado pra transação</param>
        /// <param name="idCard">Id do cartão selecionado pra transação</param>
        public static void Validation(string amount, string type, int number, int idClient, int idCard)
        {
            ValidationTransaction(amount, type, idClient, idCard);
            ValidationType(type, number);
        }

        /// <summary>
        /// Verifica se algum campo foi enviado em branco
        /// </summary>
        /// <param name="amount">Valor da transação</param>
        /// <param name="type">Tipo de transação - Débito ou crédito</param>
        /// <param name="idClient">Id do cliente selecionado pra transação</param>
        /// <param name="idCard">Id do cartão selecionado pra transação</param>
        private static void ValidationTransaction(string amount, string type, int idClient, int idCard)
        {
            if (string.IsNullOrWhiteSpace(amount) ||
                    string.IsNullOrWhiteSpace(type) ||                       
                        idClient < 1  ||
                            idCard < 1)
            {
                throw new Exception("Favor preencher nome e limite do cliente");
            }
        }

        /// <summary>
        /// Verifica o tipo da transação e o número de parcelas. Caso seja de débito não pode ter parcelas, 
        /// e se for crédito tem que ter alguma parcela
        /// </summary>
        /// <param name="type">Tipo de transação</param>
        /// <param name="number">Número de parcelas desejada</param>
        private static void ValidationType(string type, int number)
        {
            if (type.Equals("Crédito") && number < 1)                     
            {
                throw new Exception("Favor selecionar o número de parcelas desejada");
            }
            else if (type.Equals("Débito") && number > 0)
            {
                throw new Exception("Não é permitido parcelar uma transação de débito");
            }
        }
    }
}
