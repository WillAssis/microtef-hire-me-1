using DesafioStone.Domain.Contracts.Repository;
using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Infra.Repository
{
    public class RepositoryTransaction
       : RepositoryBase<Transaction>, IRepositoryTransaction
    {
    }
}
