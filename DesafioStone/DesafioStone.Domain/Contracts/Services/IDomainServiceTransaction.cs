using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Contracts.Services
{
    public interface IDomainServiceTransaction
      : IDomainServiceBase<Transaction>
    {
        void Cadastrar(Transaction obj, Card obj1, decimal limit);
    }
}
