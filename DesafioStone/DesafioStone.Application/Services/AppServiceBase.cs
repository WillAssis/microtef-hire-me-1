using DesafioStone.Application.Contracts;
using DesafioStone.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Application.Services
{
    public class AppServiceBase<TEntity>
        : IAppServiceBase<TEntity>
        where TEntity : class
    {
        private IDomainServiceBase<TEntity> dominio;

        public AppServiceBase(IDomainServiceBase<TEntity> dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return dominio.ListarTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return dominio.ObterPorId(id);
        }
    }
}
