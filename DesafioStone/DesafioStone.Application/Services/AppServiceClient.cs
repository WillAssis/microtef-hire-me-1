using DesafioStone.Application.Contracts;
using DesafioStone.Domain.Contracts.Services;
using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Application.Services
{
    public class AppServiceClient
       : AppServiceBase<Client>,
       IAppServiceClient
    {
        private IDomainServiceClient dominio;

        public AppServiceClient(IDomainServiceClient dominio)
            : base(dominio)
        {
            this.dominio = dominio;
        }
    }
}
