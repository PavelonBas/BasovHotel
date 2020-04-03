﻿using System;
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
    /// Логика взаимодействия для MenuAdm.xaml
    /// </summary>
    public partial class MenuAdm : Page
    {
        public MenuAdm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new StaffPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ClientsPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new BusyRoom());
        }
    }
}
