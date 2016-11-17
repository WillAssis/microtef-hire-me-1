using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Validation
{
    /// <summary>
    /// Classe responsável por validações básicas da página de cadastro de cliente
    /// </summary>
    public class ClientValidation
    {
        /// <summary>
        /// Verifica se algum campo foi enviado em branco
        /// </summary>
        /// <param name="name">Nome do cliente cadastrado</param>
        /// <param name="limit">Limite do Cliente</param>
        public static void Validation(string name, string limit)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(limit))
            {
                throw new Exception("Favor preencher nome e limite do cliente");
            }
        }
    }
}
