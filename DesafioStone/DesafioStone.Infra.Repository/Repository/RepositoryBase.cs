using DesafioStone.Domain.Contracts.Repository;
using DesafioStone.Infra.Repository.DataSource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Infra.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntiry"></typeparam>
    public class RepositoryBase<TEntiry> : IRepositoryBase<TEntiry>
       where TEntiry : class
    {
        protected readonly Conexao Con;

        public RepositoryBase()
        {
            Con = new Conexao();
        }

        public void Insert(TEntiry obj)
        {
            Con.Entry(obj).State = EntityState.Added;
            Con.SaveChanges();
        }

        public List<TEntiry> FindAll()
        {
            return Con.Set<TEntiry>().ToList();
        }

        public TEntiry FindById(int id)
        {
            return Con.Set<TEntiry>().Find(id);
        }
    }
}
