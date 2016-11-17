using DesafioStone.Domain.Contracts.Repository;
using DesafioStone.Domain.Contracts.Services;
using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Domain.Services
{
    public class DomainServiceClient
        : DomainServiceBase<Client>,
        IDomainServiceClient
    {
        //atributo para o repositório de dados
        private IRepositoryClient repositorio;

        public DomainServiceClient(IRepositoryClient repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }      
    }
}
