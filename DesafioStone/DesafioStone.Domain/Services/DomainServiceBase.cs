using DesafioStone.Domain.Contracts.Repository;
using DesafioStone.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Services
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity>
         where TEntity : class
    {
        //atributo para a interface do repositório
        private IRepositoryBase<TEntity> repositorio;

        public DomainServiceBase(IRepositoryBase<TEntity> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(TEntity obj)
        {
            try
            {
                repositorio.Insert(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TEntity> ListarTodos()
        {
            try
            {
                return repositorio.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TEntity ObterPorId(int id)
        {
            try
            {
                return repositorio.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
