using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Service.Model
{
    public class ClientModelCadastro
    {
        public string Name { get; set; } // Nome do Cliente
        public decimal Limit { get; set; } // Limite de Credito
    }

    public class ClientModelConsulta
    {
        public int IdClient { get; set; } // idCliente no banco
        public string Name { get; set; } // Nome do Cliente
        public decimal Limit { get; set; } // Limite de Credito
    }
}
