using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Entities
{
    public class Card
    {
        public virtual int IdCard { get; set; }
        public virtual string CardholderName { get; set; } //Nome do portador do cartão
        public virtual string CardNumber { get; set; } //Os números que são impressos no cartão, podendo variar entre 12 à 19 dígitos
        public virtual DateTime ExpirationDate { get; set; } //Data de expiração do cartão
        public virtual string CardBrand { get; set; } //Bandeira do cartão
        public virtual string Password { get; set; } //Senha do cartão
        public virtual string Type { get; set; } //Chip ou tarja magnética
        public virtual int IdClient { get; set; }
        public virtual int Status { get; set; } // 1- Ativo 0- Inativo / Bloqueado

        [NotMapped]
        public bool HasPassword
        {
            get
            {
                return Type.Equals(CardType.Chip) ? false : true;
            }
        } //Se o cartão possui senha. Apenas cartões de tarja magnética podem ter essa propriedade como True

        #region Relacionamento
        public virtual Client client { get; set; }
        public virtual List<Transaction> transaction { get; set; }
        #endregion
    }
}

public static class CardType
{
    public const string Chip = "Chip";
    public const string Tarja = "Tarja Magnética";
}