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
    /// Логика взаимодействия для BusyRoom.xaml
    /// </summary>
    public partial class BusyRoom : Page
    {
        public BusyRoom()
        {
            InitializeComponent();
            DGRooms.ItemsSource = AppData.Context.Rooms.ToList();
            CbCategory.ItemsSource = AppData.Context.Rooms.Select(p => p.Category).Distinct().ToList();
        }
        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            TBSearch.Text = "";
            CbCategory.SelectedIndex = -1;
        }
        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddRoomPage());
        }
        private void BtReAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DGRooms.SelectedIndex;
            var dataR = (Rooms)DGRooms.SelectedItems[0];
            AppData.MainFrame.Navigate(new AddRoomPage(AppData.Context.Rooms.Where(p => p.id_Room == dataR.id_Room).FirstOrDefault()));
        }
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Rooms.Remove(DGRooms.SelectedItem as Rooms);
        }
        private void Filter()
        {
            var filter = AppData.Context.Rooms.ToList();
            DGRooms.ItemsSource = filter.ToList();
            if (CbCategory.SelectedIndex != -1)
            {
                filter = filter.Where(p => p.Category == CbCategory.SelectedItem.ToString()).ToList();
            }

            if (TBSearch.Text != "")
            {
                filter = filter.Where(p => p.Price_room.ToString().Contains(TBSearch.Text)).ToList();
            }
            DGRooms.ItemsSource = filter.ToList();
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void CbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
