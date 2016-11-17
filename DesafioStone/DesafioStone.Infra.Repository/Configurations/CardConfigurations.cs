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
    /// Mapeamento da classe de entidade Card
    /// </summary>
    public class CardConfigurations : EntityTypeConfiguration<Card>
    {
        public CardConfigurations()
        {
            HasKey(c => c.IdCard);

            Property(c => c.CardholderName)
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.CardNumber)
                .IsRequired();

            Property(c => c.ExpirationDate)
                .IsRequired();

            Property(c => c.CardBrand)
                .HasMaxLength(30)
                .IsRequired();

            Property(c => c.Password)
                .HasMaxLength(6)
                .IsRequired();

            Property(c => c.Type)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Status)
               .IsRequired();

            #region Relacionamentos

            HasRequired(c => c.client) // card
                .WithMany(c => c.card) // client
                .HasForeignKey(c => c.IdClient); //card
            #endregion
        }
    }
}
