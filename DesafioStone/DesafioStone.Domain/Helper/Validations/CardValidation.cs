using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Helper.Validations
{
    /// <summary>
    /// Classe responsável por realizar as validações do cartão
    /// </summary>
    public class CardValidation
    {
        /// <summary>
        /// Responsável por realizar as validações de cartão
        /// </summary>
        /// <param name="c">Um cartão</param>
        public static void CardValidationRules(Card c)
        {
            ValidationLength(c.CardNumber);
            ValidationExpirationDate(c.ExpirationDate);
            ValidationHasPassword(c.HasPassword, c.Password);
            ValidationPassword(c.Password);
        }

        /// <summary>
        /// Verifica se o cartão enviado possui a quantidade necessária de dígitos
        /// </summary>
        /// <param name="cardNumber">Número do cartão</param>
        private static void ValidationLength(string cardNumber)
        {
            int tam = cardNumber.Length;

            if (tam < 12 || tam > 19)
            {
                throw new Exception("Os números do cartão precisam ter de 12 à 19 dígitos");
            }
        }

        /// <summary>
        /// Verifica se o cartão está vencido
        /// </summary>
        /// <param name="expirationDate">Data de vencimento do cartão</param>
        private static void ValidationExpirationDate(DateTime expirationDate)
        {
            DateTime today = DateTime.Today;

            if (expirationDate < today)
            {
                throw new Exception("Cartão vencido, favor procurar a administradora");
            }
        }

        /// <summary>
        /// Verifica se a senha do cartão possui o número de dígitos necessário
        /// </summary>
        /// <param name="password">Senha do cartão</param>
        private static void ValidationPassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                int tam = password.Length;

                if (tam < 4 || tam > 6)
                {
                    throw new Exception("Favor digitar uma senha de 4 à 6 números");
                }
            }
        }

        /// <summary>
        /// Para cartões de tarja magnética verifica se foi inserida uma senha
        /// </summary>
        /// <param name="status">Se é tarja magnética (true)</param>
        /// <param name="password">Senha do cartão</param>
        private static void ValidationHasPassword(bool status, string password)
        {
            if (status && string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Para cartões de tarja magnética a senha é obrigatória");
            }
        }
    }
}
