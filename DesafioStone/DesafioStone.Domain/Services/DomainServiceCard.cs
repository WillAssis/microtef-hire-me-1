using DesafioStone.Domain.Contracts.Repository;
using DesafioStone.Domain.Contracts.Services;
using DesafioStone.Domain.Helper.Validations;
using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Services
{
    public class DomainServiceCard
         : DomainServiceBase<Card>,
         IDomainServiceCard
    {
        //atributo para o repositório de dados
        private IRepositoryCard repositorio;

        public DomainServiceCard(IRepositoryCard repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(Card c)
        {
            try
            {
                CardValidation.CardValidationRules(c);
                repositorio.Insert(c);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }    
    }
}
