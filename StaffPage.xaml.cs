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
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
            DGStaff.ItemsSource = AppData.Context.Staff.ToList();
            CBAddress.ItemsSource = AppData.Context.Staff.Select(p => p.Address).Distinct().ToList();
        }
        private void Filter()
        {
            var filter = AppData.Context.Staff.ToList();
            DGStaff.ItemsSource = filter.ToList();
            if (CBAddress.SelectedIndex != -1)
            {
                filter = filter.Where(p => p.Address == CBAddress.SelectedItem.ToString()).ToList();
            }

            if (TBSearch.Text != "")
            {
                filter = filter.Where(p => p.SurName.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            }
            DGStaff.ItemsSource = filter.ToList();
        }
        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegistrationPage(true));
        }
        
        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "";
            CBAddress.SelectedIndex = -1;
        }

        private void CBAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Staff.Remove(DGStaff.SelectedItem as Staff);
            AppData.Context.SaveChanges();
            DGStaff.ItemsSource = AppData.Context.Staff.ToList();
        }
        
        private void BtReAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DGStaff.SelectedIndex;
            var dataR = (Staff)DGStaff.SelectedItems[0];
            AppData.MainFrame.Navigate(new RegistrationPage(AppData.Context.Staff.Where(p => p.id_Staff == dataR.id_Staff).FirstOrDefault()));
        }
    }
}
