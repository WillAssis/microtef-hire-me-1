using DesafioStone.Entities;
using DesafioStone.Infra.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStone.Infra.Repository.DataSource
{
    /// <summary>
    /// Classe de conexão com a base de dados
    /// </summary>
    public class Conexao : DbContext
    {
        public Conexao()
         : base(ConfigurationManager.ConnectionStrings["stone"].ConnectionString)
        {

        }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //alterar definições do entityframework
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //classes de mapeamento
            modelBuilder.Configurations.Add(new ClientConfigurations());
            modelBuilder.Configurations.Add(new CardConfigurations());
            modelBuilder.Configurations.Add(new TransactionConfigurations());
        }

        //declarar um DbSet para cada entidade
        public DbSet<Client> client { get; set; }
        public DbSet<Card> card { get; set; }
        public DbSet<Transaction> transaction { get; set; }
    }
}
