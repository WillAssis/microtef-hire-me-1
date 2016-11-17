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
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
        }

        private void MenuItem_Cliente(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CadastroCliente.xaml", UriKind.Relative));
        }

        private void MenuItem_Cartao(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CadastroCartao.xaml", UriKind.Relative));
        }

        private void MenuItem_Transacao(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Transacao.xaml", UriKind.Relative));
        }

        private void MenuItem_ListaTransacao(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/ListaTransacoes.xaml", UriKind.Relative));
        }
    }
}
