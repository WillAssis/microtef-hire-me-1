using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.OldButGold.Service.Model
{
    public class CardModelCadastro
    {
        public virtual string CardholderName { get; set; } //Nome do portador do cartão
        public virtual string CardNumber { get; set; } //Os números que são impressos no cartão, podendo variar entre 12 à 19 dígitos
        public virtual string ExpirationDate { get; set; } //Data de expiração do cartão
        public virtual string CardBrand { get; set; } //Bandeira do cartão
        public virtual string Password { get; set; } //Senha do cartão
        public virtual string Type { get; set; } //Chip ou tarja magnética
        public virtual int IdClient { get; set; }
        public virtual int Status { get; set; }
    }

    public class CardModelConsulta
    {
        public virtual int IdCard { get; set; }
        public virtual string CardholderName { get; set; } //Nome do portador do cartão
        public virtual string CardNumber { get; set; } //Os números que são impressos no cartão, podendo variar entre 12 à 19 dígitos
        public virtual DateTime ExpirationDate { get; set; } //Data de expiração do cartão
        public virtual string CardBrand { get; set; } //Bandeira do cartão
        public virtual string Password { get; set; } //Senha do cartão
        public virtual string Type { get; set; } //Chip ou tarja magnética
        public virtual int IdClient { get; set; }
        public virtual int Status { get; set; }
    }
}
