using DesafioStone.Entities;
using DesafioStone.OldButGold.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesafioStone.OldButGold.Pages
{
    /// <summary>
    /// Interaction logic for ListaTransacoes.xaml
    /// </summary>
    public partial class ListaTransacoes : Page
    {
        public ListaTransacoes()
        {
            InitializeComponent();
            CreateDynamicGridView();
        }

        private void CreateDynamicGridView()
        {
            List<Transaction> items = new List<Transaction>();
            foreach (Transaction t in OldButGoldService.GetRequestTransaction().OrderBy(t=>t.IdTransaction))
            {
                t.client = OldButGoldService.GetIdRequestClient(t.IdClient);
                t.card = OldButGoldService.GetIdRequestCard(t.IdCard);

                items.Add(new Transaction() { IdTransaction = t.IdTransaction, Amount = t.Amount, Type = t.Type, Number = t.Number, IdClient = t.IdClient, IdCard = t.IdCard, ClientName = t.client.Name, CardNumber = t.card.CardNumber });            
            };

            if (items.Count < 1)
            {
                MessageBox.Show("Não existe transação disponível para consulta");               
            }
            else
            {
                lvTransactions.ItemsSource = items;
            }            
        }
    }
}
