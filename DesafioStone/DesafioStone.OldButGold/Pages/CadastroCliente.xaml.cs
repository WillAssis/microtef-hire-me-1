using DesafioStone.Entities;
using DesafioStone.OldButGold.Service;
using DesafioStone.OldButGold.Validation;
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
    /// Interaction logic for CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Page
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientValidation.Validation(name.Text, limit.Text);

                Client c = new Client()
                {
                    Name = name.Text,
                    Limit = Decimal.Parse(limit.Text)
                };

                string status = OldButGoldService.PostRequestClient(c);
                MessageBox.Show(status);
                this.NavigationService.Navigate(new Uri("Pages/Index.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Você deseja realmente cancelar?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    this.NavigationService.Navigate(new Uri("Pages/Index.xaml", UriKind.Relative));
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
