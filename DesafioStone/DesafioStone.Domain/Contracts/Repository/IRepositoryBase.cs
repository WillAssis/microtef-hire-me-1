using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Contracts.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        List<TEntity> FindAll();
        TEntity FindById(int id);
    }
}
