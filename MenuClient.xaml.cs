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
    /// Логика взаимодействия для MenuClient.xaml
    /// </summary>
    public partial class MenuClient : Page
    {
        public MenuClient()
        {
            InitializeComponent();
            CbHr.ItemsSource = AppData.Context.Rooms.Where(p => p.Busy_room == false).Select(p => p.id_Room).ToList();
            CbService.ItemsSource = AppData.Context.Services.Select(p => p.Name_Services).ToList();
        }
        int price;

        private void CbHr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            price = Convert.ToInt32(AppData.Context.Rooms.Where(p => Convert.ToInt32(CbHr.SelectedItem) == p.id_Room).FirstOrDefault().Price_room);
            TextBPrice.Text = price.ToString();
            TbCategory.Text = AppData.Context.Rooms.Where(p => Convert.ToInt32(CbHr.SelectedItem) == p.id_Room).Single().Category.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
