using DesafioStone.Entities;
using DesafioStone.OldButGold.Service.Model;
using DesafioStone.OldButGold.Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DesafioStone.OldButGold.Service
{
    /// <summary>
    /// Classe responsável por montar a url e o Json da web api 
    /// </summary>
    public class ClientService
    {
        //Url do controller de client da web api
        private const string _localHost = "http://localhost:60364/api/client/";

        /// <summary>
        /// Recebe um objeto de cliente e cria a url e o json para fazer a requisição via post para web api
        /// </summary>
        /// <param name="c">Um objeto de cliente</param>
        /// <returns>Status da operação</returns>
        public static string ClientPostRequest(Client c)
        {
            //string x = System.Configuration.ConfigurationManager.AppSettings["URL_API"];
            string URL = string.Format("{0}{1}", _localHost, "cadastrar");
            string jsondata = string.Format("Name={0}&Limit={1}", c.Name, c.Limit);

            ApiRequest myRequest = new ApiRequest(URL, "POST", jsondata);
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<string>(myRequest.GetResponse());
        }

        /// <summary>
        /// Cria a url e o json para fazer a requisição via get para web api
        /// </summary>
        /// <returns>Lista de clientes cadastrados</returns>
        public static List<Client> ClientGetRequest()
        {
            ApiRequest myRequest;
            List<Client> client = new List<Client>();
            string URL = string.Format("{0}{1}", _localHost, "listar");
            
            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<ClientModelConsulta> objects = js.Deserialize<List<ClientModelConsulta>>(myRequest.GetResponse());

            foreach (ClientModelConsulta model in objects)
            {
                Client c = new Client()
                {
                    IdClient = model.IdClient,
                    Name = model.Name,
                    Limit = model.Limit
                };
                client.Add(c);
            }
            return client;        
        }

        /// <summary>
        /// Cria a url e o json para fazer a requisição via get para web api
        /// </summary>
        /// <param name="id">id do cliente desejado</param>
        /// <returns>Um cliente referente ao id passado</returns>
        public static Client ClientIdGetRequest(int id)
        {
            ApiRequest myRequest;
            Client c = null;

            string URL = string.Format("{0}{1}?id={2}", _localHost, "obter",id);
            
            myRequest = new ApiRequest(URL, "GET");
            JavaScriptSerializer js = new JavaScriptSerializer();
            ClientModelConsulta client = js.Deserialize<ClientModelConsulta>(myRequest.GetResponse());

            if (client != null)
            {
                c = new Client()
                {
                    IdClient = client.IdClient,
                    Name = client.Name,
                    Limit = client.Limit
                };
            }
            return c;
        }
    }
}
