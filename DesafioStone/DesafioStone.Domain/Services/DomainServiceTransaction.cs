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
    public class DomainServiceTransaction
        : DomainServiceBase<Transaction>,
        IDomainServiceTransaction
    {
        //atributo para o repositório de dados
        private IRepositoryTransaction repositorio;

        public DomainServiceTransaction(IRepositoryTransaction repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(Transaction t, Card c, decimal limit)
        {
            try
            {
                CardValidation.CardValidationRules(c);
                TransactionValidation.TransactionValidationRules(t, limit, c.Status);
                repositorio.Insert(t);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
