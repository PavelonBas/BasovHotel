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
    /// Логика взаимодействия для AddRoomPage.xaml
    /// </summary>
    public partial class AddRoomPage : Page
    {
        private Rooms rooms;

        public AddRoomPage()
        {
            InitializeComponent();

        }

        public AddRoomPage(Rooms rooms)
        {
            InitializeComponent();
            this.rooms = rooms;
            tbNumber.Text = rooms.Num_of_beds_room.ToString();
            tbPrice.Text = rooms.Price_room.ToString();
            TbCategory.Text = rooms.Category;
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Rooms.Add(
               new Rooms()
               {
                   Busy_room = false,
                   Category = TbCategory.Text,
                   Price_room = Convert.ToInt32(tbPrice.Text),
                   Num_of_beds_room = Convert.ToInt32(tbNumber.Text)

               });
            AppData.Context.SaveChanges();
            MessageBox.Show($"Добавление комнаты успешна", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            AppData.MainFrame.GoBack();
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            tbNumber.Text = "";
            TbCategory.Text = "";
            tbPrice.Text = "";
        }
    }
}
