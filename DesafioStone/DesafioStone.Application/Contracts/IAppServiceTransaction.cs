using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Application.Contracts
{
    public interface IAppServiceTransaction
       : IAppServiceBase<Transaction>
    {
        void Cadastrar(Transaction obj, Card obj1, decimal limite);
    }
}
