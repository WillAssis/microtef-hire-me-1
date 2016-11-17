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
    /// Interaction logic for CadastroCartao.xaml
    /// </summary>
    public partial class CadastroCartao : Page
    {
        public CadastroCartao()
        {
            InitializeComponent();
            loadCombBox();
        }

        private void loadCombBox()
        {
            ClientName.Items.Add(new Client { Name = "-- Selecione --" });
            foreach (Client c in OldButGoldService.GetRequestClient())
            {
                ClientName.DisplayMemberPath = "Name";
                ClientName.SelectedValue = "IdClient";
                ClientName.Items.Add(new Client { Name = c.Name, IdClient = c.IdClient });
            }

            ClientName.SelectedIndex = 0;
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            try
            {
                Client selectedClient = (Client)ClientName.SelectedValue;
                ComboBoxItem selectedType = (ComboBoxItem)Type.SelectedValue;
                ComboBoxItem selectedCardBrand = (ComboBoxItem)CardBrand.SelectedValue;

                string type = (string)selectedType.Content;
                string cardBrand = (string)selectedCardBrand.Content;

                CardValidation.Validation(CardholderName.Text, Number.Text, ExpirationDate.Text, cardBrand, type, selectedClient.IdClient);

                Card card = new Card()
                {
                    CardholderName = CardholderName.Text,
                    CardNumber = Number.Text,
                    ExpirationDate = (DateTime) ExpirationDate.SelectedDate,
                    CardBrand = cardBrand,
                    Password = Password.Password,
                    Type = type,
                    IdClient = selectedClient.IdClient,
                    Status = 1
                    
                };

                string status = OldButGoldService.PostRequestCard(card);
                MessageBox.Show(status);
                this.NavigationService.Navigate(new Uri("Pages/Index.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Cancelar(object sender, RoutedEventArgs e)
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
