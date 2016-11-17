using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Entities
{
    public class Transaction
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; } //Valor da transação
        public string Type { get; set; } //Tipo da transação
        public int Number { get; set; } //Número de parcelas, se for uma transação de crédito parcelado
        public int IdClient { get; set; }
        public int IdCard { get; set; }

        [NotMapped]
        public string ClientName { get; set; }
        [NotMapped]
        public string CardNumber { get; set; }

        #region Relacionamentos
        public Client client { get; set; }
        public Card card { get; set; }
        #endregion
    }
}
