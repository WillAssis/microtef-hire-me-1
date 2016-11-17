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
    public class CardService
    {
        private const string _localHost = "http://localhost:60364/api/card/";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string CardPostRequest(Card c)
        {
            //string x = System.Configuration.ConfigurationManager.AppSettings["URL_API"];
            string URL = string.Format("{0}{1}", _localHost, "cadastrar");
            string jsondata = string.Format("CardholderName={0}&CardNumber={1}&ExpirationDate={2}&CardBrand={3}&Password={4}&Type={5}&IdClient={6}&Status={7}", 
                                                 c.CardholderName, c.CardNumber, c.ExpirationDate, c.CardBrand, c.Password, c.Type, c.IdClient, c.Status);
            
            ApiRequest myRequest = new ApiRequest(URL, "POST", jsondata);
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<string>(myRequest.GetResponse());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Card> CardGetRequest()
        {
            ApiRequest myRequest;
            List<Card> card = new List<Card>();
            string URL = string.Format("{0}{1}", _localHost, "listar");

            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<CardModelConsulta> objects = js.Deserialize<List<CardModelConsulta>>(myRequest.GetResponse());

            foreach (CardModelConsulta model in objects)
            {
                Card c = new Card()
                {
                    IdCard = model.IdCard,
                    CardholderName = model.CardholderName,
                    CardNumber = model.CardNumber,
                    ExpirationDate = model.ExpirationDate,
                    CardBrand = model.CardBrand,
                    Password = model.Password,
                    Type = model.Type,
                    IdClient = model.IdClient,
                    Status = model.Status                    
                };
                card.Add(c);
            }
            return card;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Card CardIdGetRequest(int id)
        {
            ApiRequest myRequest;
            Card c = null;

            string URL = string.Format("{0}{1}?id={2}", _localHost, "obter", id);

            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            CardModelConsulta card = js.Deserialize<CardModelConsulta>(myRequest.GetResponse());

            if (card != null)
            {
                c = new Card()
                {
                    IdCard = card.IdCard,
                    CardholderName = card.CardholderName,
                    CardNumber = card.CardNumber,
                    ExpirationDate = card.ExpirationDate,
                    CardBrand = card.CardBrand,
                    Password = card.Password,
                    Type = card.Type,
                    IdClient = card.IdClient,
                    Status = card.Status
                };
            }
            return c;
        }
    }
}
