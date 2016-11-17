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
    /// Controller responsável pelas operações com a entidade card
    /// </summary>
    [RoutePrefix("api/card")]
    public class CardController : ApiController
    {
        private IAppServiceCard appCard;

        public CardController(IAppServiceCard appCard)
        {
            this.appCard = appCard;
        }

        /// <summary>
        /// Responsável por cadastrar um cartão 
        /// </summary>
        /// <param name="model">Model recebida do cliente</param>
        /// <returns>Status da operação</returns>
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(CardModelCadastro model)
        {
            try
            {
                Card c = new Card()
                {
                    CardholderName = model.CardholderName,
                    CardNumber = model.CardNumber,
                    ExpirationDate = DateTime.Parse(model.ExpirationDate),
                    CardBrand = model.CardBrand,
                    Password = model.Password,
                    Type = model.Type,
                    IdClient = model.IdClient,
                    Status = model.Status
                    
                };

                appCard.Cadastrar(c);

                return Request.CreateResponse(HttpStatusCode.OK, "Cartão cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Resposnsável por listar todos os cartões cadastrados
        /// </summary>
        /// <returns>Lista dos cartões cadastrados no sistema</returns>
        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage GetValues()
        {
            try
            {
                List<CardModelConsulta> lista = new List<CardModelConsulta>();

                foreach (Card c in appCard.ListarTodos())
                {
                    CardModelConsulta model = new CardModelConsulta()
                    {
                        IdCard = c.IdCard,
                        CardholderName = c.CardholderName,
                        CardNumber = c.CardNumber,
                        ExpirationDate = c.ExpirationDate,
                        CardBrand = c.CardBrand,
                        Password = c.Password,
                        Type = c.Type,
                        IdClient = c.IdClient,
                        Status = c.Status
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
        /// Reponsável por procurar um cartão através de seu id
        /// </summary>
        /// <param name="id">Id do cartão enviado pelo cliente</param>
        /// <returns>cartão correspondente ao id enviado</returns>
        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                Card c = appCard.ObterPorId(id);

                if (c != null)
                {
                    CardModelConsulta model = new CardModelConsulta()
                    {
                        IdCard = c.IdCard,
                        CardholderName = c.CardholderName,
                        CardNumber = c.CardNumber,
                        ExpirationDate = c.ExpirationDate,
                        CardBrand = c.CardBrand,
                        Password = c.Password,
                        Type = c.Type,
                        IdClient = c.IdClient,
                        Status = c.Status
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    throw new Exception("Cartão não encontrado.");
                }

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
