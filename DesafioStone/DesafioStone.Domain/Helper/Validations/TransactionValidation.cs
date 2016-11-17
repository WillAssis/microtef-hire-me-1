using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Helper.Validations
{
    /// <summary>
    /// Classe responsável por realizar as validações da transação
    /// </summary>
    public class TransactionValidation
    {
        /// <summary>
        /// Responsável por realizar as validações da transação
        /// </summary>
        /// <param name="t">Objeto da transação</param>
        /// <param name="limit">limite do cliente</param>
        /// <param name="status">Status do cartão (Bloqueado - 0 ou ativo - 1)</param>
        public static void TransactionValidationRules(Transaction t, decimal limit, int status)
        {
            ValidationSaldo(t.Amount);
            ValidationSaldo(t.Amount, limit);
            ValidationStatus(status);
        }

        /// <summary>
        /// Responsável por verificar se o cliente possui saldo suficiente para realizar a transação
        /// </summary>
        /// <param name="amount">Valor da transação</param>
        /// <param name="limit">Limite do cliente</param>
        private static void ValidationSaldo(decimal amount, decimal limit)
        {
            if (amount > limit)
            {
                throw new Exception("Saldo insuficiente");
            }
        }

        /// <summary>
        /// Verifica se o valor da transação é maior do que o mínimo permitido
        /// </summary>
        /// <param name="amount">Valor da transação</param>
        private static void ValidationSaldo(decimal amount)
        {
            decimal min = new decimal(0.10);
            if (amount < min)
            {
                throw new Exception("Valor inválido! Mínimo de 10 centavos");
            }
        }

        /// <summary>
        /// Verifica se o cartão está bloqueado
        /// </summary>
        /// <param name="status">Status do cartão</param>
        private static void ValidationStatus(int status)
        {
            if (status == 0)
            {
                throw new Exception("Cartão bloqueado");
            }
        }
    }
}
