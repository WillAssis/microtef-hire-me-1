using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Entities
{
    public class Client
    {
        public virtual int IdClient { get; set; }
        public virtual string Name { get; set; } // Nome do Cliente
        public virtual decimal Limit { get; set; } // Limite de Credito

        #region Relacionamentos
        public virtual List<Card> card { get; set; }
        public virtual List<Transaction> transaction { get; set; }
        #endregion
    }
}
