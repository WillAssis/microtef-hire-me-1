using DesafioStone.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Infra.Repository.Configurations
{
    /// <summary>
    /// Mapeamento da classe de entidade Client
    /// </summary>
    public class ClientConfigurations : EntityTypeConfiguration<Client>
    {
        public ClientConfigurations()
        {
            HasKey(c => c.IdClient);

            Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Limit)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
