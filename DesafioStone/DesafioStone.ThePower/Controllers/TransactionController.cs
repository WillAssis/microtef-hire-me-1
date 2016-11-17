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
    /// Controller responsável pelas operações com a entidade transaction
    /// </summary>
    [RoutePrefix("api/transaction")]
    public class TransactionController : ApiController
    {
        private IAppServiceCard appCard;
        private IAppServiceClient appClient;
        private IAppServiceTransaction appTransaction;

        public TransactionController(IAppServiceClient appClient, IAppServiceTransaction appTransaction, IAppServiceCard appCard)
        {
            this.appCard = appCard;
            this.appClient = appClient;
            this.appTransaction = appTransaction;
        }

        /// <summary>
        /// Responsável por cadastrar uma transação 
        /// </summary>
        /// <param name="model">Model recebida da transação</param>
        /// <returns>Status da operação</returns>
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(TransactionModelCadastro model)
        {
            try
            {
                Client c = appClient.ObterPorId(model.IdClient);
                Card card = appCard.ObterPorId(model.IdCard);

                Transaction t = new Transaction()
                {
                    Amount = model.Amount,
                    Type = model.Type,
                    Number = model.Number,
                    IdClient = model.IdClient,
                    IdCard = model.IdCard
                };

                appTransaction.Cadastrar(t, card, c.Limit);

                return Request.CreateResponse(HttpStatusCode.OK, "Transação aprovada.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Resposnsável por listar todos as transações cadastradas
        /// </summary>
        /// <returns>Lista das transações cadastradas no sistema</returns>
        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage GetValues()
        {
            try
            {
                List<TransactionModelConsulta> lista = new List<TransactionModelConsulta>();

                foreach (Transaction t in appTransaction.ListarTodos())
                {
                    TransactionModelConsulta model = new TransactionModelConsulta()
                    {
                        IdTransaction = t.IdTransaction,
                        Amount = t.Amount,
                        Type = t.Type,
                        Number = t.Number,
                        IdClient = t.IdClient,
                        IdCard = t.IdCard
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
        /// Reponsável por procurar uma transação através de seu id
        /// </summary>
        /// <param name="id">Id da transação enviado pelo cliente</param>
        /// <returns>transação correspondente ao id enviado</returns>
        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                Transaction t = appTransaction.ObterPorId(id);

                if (t != null)
                {
                    TransactionModelConsulta model = new TransactionModelConsulta()
                    {
                        IdTransaction = t.IdTransaction,
                        Amount = t.Amount,
                        Type = t.Type,
                        Number = t.Number,
                        IdClient = t.IdClient,
                        IdCard = t.IdCard
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    throw new Exception("Transação não encontrada.");
                }

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
