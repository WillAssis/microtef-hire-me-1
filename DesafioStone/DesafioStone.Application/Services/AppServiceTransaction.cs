using DesafioStone.Application.Contracts;
using DesafioStone.Domain.Contracts.Services;
using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Application.Services
{
    public class AppServiceTransaction
       : AppServiceBase<Transaction>,
       IAppServiceTransaction
    {
        private IDomainServiceTransaction dominio;

        public AppServiceTransaction(IDomainServiceTransaction dominio)
            : base(dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(Transaction obj, Card obj1, decimal limit)
        {
            dominio.Cadastrar(obj, obj1, limit);
        }
    }
}
