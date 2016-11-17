using DesafioStone.Entities;
using DesafioStone.OldButGold.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Service
{
    /// <summary>
    /// Classe responsável por chamar a camada de serviço do cliente
    /// </summary>
    public class OldButGoldService
    {
        #region Cliente
        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando um cliente que será enviado para o servidor
        /// </summary>
        /// <param name="c">Objeto da classe Client</param>
        /// <returns>Status da requisição</returns>
        public static string PostRequestClient(Client c)
        {
            return ClientService.ClientPostRequest(c);           
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold que fara requisição ao servidor
        /// </summary>
        /// <returns>Lista de clientes retornada pelo serviço</returns>
        public static List<Client> GetRequestClient()
        {
            return ClientService.ClientGetRequest();
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando um id do cliente que será requisitado para o servidor
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Um cliente retornado pelo servidor</returns>
        public static Client GetIdRequestClient(int id)
        {
            return ClientService.ClientIdGetRequest(id);
        }
        #endregion

        #region Cartão
        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando um cartão que será enviado para o servidor
        /// </summary>
        /// <param name="card">Objeto da classe Card</param>
        /// <returns>Status da requisição</returns>
        public static string PostRequestCard(Card card)
        {           
            return CardService.CardPostRequest(card);         
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold que fara requisição ao servidor
        /// </summary>
        /// <returns>Lista de cartões retornada pelo serviço</returns>
        public static List<Card> GetRequestCard()
        {
            return CardService.CardGetRequest();
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando um id do cartão que será requisitado para o servidor
        /// </summary>
        /// <param name="id">Id do cartão</param>
        /// <returns>Um cartão retornado pelo servidor</returns>
        public static Card GetIdRequestCard(int id)
        {
            return CardService.CardIdGetRequest(id);
        }
        #endregion

        #region Transação
        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando uma transação que será enviado para o servidor
        /// </summary>
        /// <param name="t">Objeto da classe Transaction</param>
        /// <returns>Status da requisição</returns>
        public static string PostRequestTransaction(Transaction t)
        {
            return TransactionService.TransactionPostRequest(t);
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold que fara requisição ao servidor
        /// </summary>
        /// <returns>Lista de transações retornada pelo serviço</returns>
        public static List<Transaction> GetRequestTransaction()
        {
            return TransactionService.TransactionGetRequest();
        }

        /// <summary>
        /// Chama a camada de serviço do Old But Gold passando um id da transação que será requisitada para o servidor
        /// </summary>
        /// <param name="id">Id da transação</param>
        /// <returns>Uma transação retornada pelo servidor</returns>
        public static Transaction GetIdRequestTransaction(int id)
        {
            return TransactionService.TransactionIdGetRequest(id);
        }
        #endregion
    }
}
