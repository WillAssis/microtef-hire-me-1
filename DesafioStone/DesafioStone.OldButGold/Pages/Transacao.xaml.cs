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
    /// Interaction logic for Transacao.xaml
    /// </summary>
    public partial class Transacao : Page
    {
        public Transacao()
        {
            InitializeComponent();
            loadClientCombBox();            
        }

        private void loadClientCombBox()
        {
            ClientName.DisplayMemberPath = "Name";
            ClientName.SelectedValue = "IdClient";
            ClientName.Items.Add(new Client { Name = "-- Selecione --" , IdClient = 0});

            foreach (Client c in OldButGoldService.GetRequestClient())
            {
                ClientName.DisplayMemberPath = "Name";
                ClientName.SelectedValue = "IdClient";
                ClientName.Items.Add(new Client { Name = c.Name, IdClient = c.IdClient });
            }

            ClientName.SelectedIndex = 0;
        }

        private void loadCardCombBox(int id)
        {
            CardNumber.Items.Clear();

            CardNumber.DisplayMemberPath = "CardNumber";
            CardNumber.SelectedValue = "IdCard";
            CardNumber.Items.Add(new Card { CardNumber = "-- Selecione --", IdCard = 0 });

            foreach (Card c in OldButGoldService.GetRequestCard().Where( c => c.IdClient == id))
            {
                CardNumber.DisplayMemberPath = "CardNumber";
                CardNumber.SelectedValue = "IdCard";
                CardNumber.Items.Add(new Card { CardNumber = c.CardNumber, IdCard = c.IdCard });
            };      
            CardNumber.SelectedIndex = 0;
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            try
            {
                Client selectedClient = (Client)ClientName.SelectedValue;
                Card selectedCard = (Card)CardNumber.SelectedValue;
                ComboBoxItem selectedType = (ComboBoxItem)Type.SelectedValue;
                ComboBoxItem selectedNumber = (ComboBoxItem)Number.SelectedValue;
                
                string type = (string)selectedType.Content;
                string number = (string)selectedNumber.Tag;

                TransactionValidation.Validation(Amount.Text, type, Int16.Parse(number), selectedClient.IdClient, selectedCard.IdCard);

                Transaction t = new Transaction()
                {
                    Amount = Decimal.Parse(Amount.Text),
                    Type = type,
                    Number = Int16.Parse(number),
                    IdClient = selectedClient.IdClient,
                    IdCard = selectedCard.IdCard
                };

                string status = OldButGoldService.PostRequestTransaction(t);
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

        private void ClientName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client selectedClient = (Client)ClientName.SelectedValue;
            loadCardCombBox(selectedClient.IdClient);
        }
    }
}
