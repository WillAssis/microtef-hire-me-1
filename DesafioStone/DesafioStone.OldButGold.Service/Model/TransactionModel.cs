using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Service.Model
{  
    public class TransactionModelCadastro
    {
        public decimal Amount { get; set; } //Valor da transação
        public string Type { get; set; } //Tipo da transação
        public int Number { get; set; } //Número de parcelas, se for uma transação de crédito parcelado
        public int IdClient { get; set; }
        public int IdCard { get; set; }
    }

    public class TransactionModelConsulta
    {
        public int IdTransaction { get; set; }
        public decimal Amount { get; set; } //Valor da transação
        public string Type { get; set; } //Tipo da transação
        public int Number { get; set; } //Número de parcelas, se for uma transação de crédito parcelado
        public int IdClient { get; set; }
        public int IdCard { get; set; }
    }   
}
