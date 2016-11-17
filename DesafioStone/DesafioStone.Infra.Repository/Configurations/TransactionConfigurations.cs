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
    /// Mapeamento da classe de entidade Transaction
    /// </summary>
    public class TransactionConfigurations : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfigurations()
        {
            HasKey(t => t.IdTransaction);

            Property(t => t.Amount)
               .HasPrecision(18, 2)
               .IsRequired();

            Property(t => t.Type)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.Number)
                .IsRequired();

            #region Relacionamentos

            HasRequired(t => t.client) // transaction
                .WithMany(c => c.transaction) // client
                .HasForeignKey(t => t.IdClient); //transaction

            HasRequired(t => t.card) // transaction
                .WithMany(c => c.transaction) // card
                .HasForeignKey(t => t.IdCard); //transaction
            #endregion

        }
    }
}
