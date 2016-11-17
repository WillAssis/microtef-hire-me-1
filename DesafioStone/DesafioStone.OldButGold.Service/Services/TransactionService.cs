using DesafioStone.Entities;
using DesafioStone.OldButGold.Service.Model;
using DesafioStone.OldButGold.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DesafioStone.OldButGold.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionService
    {
        private const string _localHost = "http://localhost:60364/api/transaction/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string TransactionPostRequest(Transaction t)
        {          
            //string x = System.Configuration.ConfigurationManager.AppSettings["URL_API"];
            string URL = string.Format("{0}{1}", _localHost, "cadastrar");
            string jsondata = string.Format("Amount={0}&Type={1}&Number={2}&IdClient={3}&IdCard={4}",
                                                 t.Amount, t.Type, t.Number, t.IdClient, t.IdCard);

            ApiRequest myRequest = new ApiRequest(URL, "POST", jsondata);
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<string>(myRequest.GetResponse());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Transaction> TransactionGetRequest()
        {
            ApiRequest myRequest;
            List<Transaction> transaction = new List<Transaction>();
            string URL = string.Format("{0}{1}", _localHost, "listar");

            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<TransactionModelConsulta> objects = js.Deserialize<List<TransactionModelConsulta>>(myRequest.GetResponse());

            foreach (TransactionModelConsulta model in objects)
            {
                Transaction t = new Transaction()
                {
                    IdTransaction = model.IdTransaction,
                    Amount = model.Amount,
                    Type = model.Type,
                    Number = model.Number,
                    IdClient = model.IdClient,
                    IdCard = model.IdCard
                };
                transaction.Add(t);
            }
            return transaction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Transaction TransactionIdGetRequest(int id)
        {
            ApiRequest myRequest;
            Transaction t = null;

            string URL = string.Format("{0}{1}?id={2}", _localHost, "obter", id);

            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            TransactionModelConsulta transaction = js.Deserialize<TransactionModelConsulta>(myRequest.GetResponse());

            if (transaction != null)
            {
                t = new Transaction()
                {
                    IdTransaction = transaction.IdTransaction,
                    Amount = transaction.Amount,
                    Type = transaction.Type,
                    Number = transaction.Number,
                    IdClient = transaction.IdClient,
                    IdCard = transaction.IdCard
                };
            }
            return t;
        }
    }
}
