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
        
        
        private void CbHr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
