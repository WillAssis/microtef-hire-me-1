using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Application.Contracts
{
    public interface IAppServiceBase<TEntity>
      where TEntity : class
    {
        void Cadastrar(TEntity obj);
        List<TEntity> ListarTodos();
        TEntity ObterPorId(int id);
    }
}
