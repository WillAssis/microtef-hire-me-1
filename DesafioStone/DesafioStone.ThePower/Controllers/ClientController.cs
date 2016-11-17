using DesafioStone.Application.Contracts;
using DesafioStone.Entities;
using DesafioStone.ThePower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesafioStone.ThePower.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações com a entidade client
    /// </summary>
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {

        private IAppServiceClient appClient;

        public ClientController(IAppServiceClient appClient)
        {
            this.appClient = appClient;
        }

        /// <summary>
        /// Responsável por cadastrar um cliente 
        /// </summary>
        /// <param name="model">Model recebida do cliente</param>
        /// <returns>Status da operação</returns>
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(ClientModelCadastro model)
        {
            try
            {
                Client c = new Client()
                {
                    Name = model.Name,
                    Limit = model.Limit
                };

                appClient.Cadastrar(c);

                return Request.CreateResponse(HttpStatusCode.OK, "Cliente cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Resposnsável por listar todos os clientes cadastrados
        /// </summary>
        /// <returns>Lista dos clientes cadastrados no sistema</returns>
        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage GetValues()
        {
            try
            {
                List<ClientModelConsulta> lista = new List<ClientModelConsulta>();

                foreach (Client c in appClient.ListarTodos())
                {
                    ClientModelConsulta model = new ClientModelConsulta()
                    {
                        IdClient = c.IdClient,
                        Name = c.Name,
                        Limit = c.Limit
                    };

                    lista.Add(model);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Reponsável por procurar um cliente através de seu id
        /// </summary>
        /// <param name="id">Id do cliente (entidade client) enviado pelo cliente (projeto)</param>
        /// <returns>cliente correspondente ao id enviado</returns>
        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                Client c = appClient.ObterPorId(id);

                if (c != null)
                {
                    ClientModelConsulta model = new ClientModelConsulta()
                    {
                        IdClient = c.IdClient,
                        Name = c.Name,
                        Limit = c.Limit
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    throw new Exception("Cliente não encontrado.");
                }

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
