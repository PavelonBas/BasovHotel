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

namespace BasovHotel
{
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            DGClient.ItemsSource = AppData.Context.Clients.ToList();
            CBAddress.ItemsSource = AppData.Context.Clients.Select(p => p.Address).Distinct().ToList();
        }
        private void Filter()
        {
            var filter = AppData.Context.Clients.ToList();
            DGClient.ItemsSource = filter.ToList();
            if (CBAddress.SelectedIndex != -1)
            {
                filter = filter.Where(p => p.Address == CBAddress.SelectedItem.ToString()).ToList();
            }

            if (TBSearch.Text != "")
            {
                filter = filter.Where(p => p.SurName.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            }
            DGClient.ItemsSource = filter.ToList();
        }
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Clients.Remove(DGClient.SelectedItem as Clients);
            AppData.Context.SaveChanges();
            DGClient.ItemsSource = AppData.Context.Clients.ToList();
        }
        private void BtReAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DGClient.SelectedIndex; 
            var dataR = (Clients)DGClient.SelectedItems[0];
            AppData.MainFrame.Navigate(new RegistrationPage(AppData.Context.Clients.Where(p => p.id_Client == dataR.id_Client).FirstOrDefault()));
        }
        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegistrationPage());
        }
        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "";
            CBAddress.SelectedIndex = -1;
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {Filter();}
        private void CBAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {Filter();}
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGClient.ItemsSource = AppData.Context.Clients.ToList();
            CBAddress.ItemsSource = AppData.Context.Clients.Select(p => p.Address).Distinct().ToList();
        }
    }
}
