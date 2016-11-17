using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Contracts.Services
{
    /// <summary>
    /// Interface para classe DomainServiceBase da camada de dominio
    /// </summary>
    public interface IDomainServiceBase<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity obj);       
        List<TEntity> ListarTodos();
        TEntity ObterPorId(int id);
    }
}
