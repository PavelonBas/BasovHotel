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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            Save();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == "")
                MessageBox.Show($"Введите Login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            if (TbPassword.Password == "")
                MessageBox.Show($"Введите пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            var User = AppData.Context.Users.Where(p => p.Login == TbLogin.Text).FirstOrDefault();
            if (User != null)
            {
                if (User == AppData.Context.Users.Where(p => p.Login == TbLogin.Text && p.Password == TbPassword.Password).FirstOrDefault())
                {
                    switch (User.Role)
                    {
                        case 1:
                            if (Checkb.IsChecked == true)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = TbPassword.Password;
                                Properties.Settings.Default.Save();
                            }
                            if (Checkb.IsChecked == false)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = "";
                                Properties.Settings.Default.Save();
                            }
                            MessageBox.Show($"Добро пожаловать Сотрудник {TbLogin.Text} ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppData.UserName = TbLogin.Text;
                            AppData.MainFrame.Navigate(new MenuAdm());
                            break;
                        case 2:
                            if (Checkb.IsChecked == true)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = TbPassword.Password;
                                Properties.Settings.Default.Save();
                            }
                            if (Checkb.IsChecked == false)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = "";
                                Properties.Settings.Default.Save();
                            }
                            MessageBox.Show($"Добро пожаловать Клиент {TbLogin.Text}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppData.UserName = TbLogin.Text;
                            AppData.MainFrame.Navigate(new MenuClient());
                            break;
                        case 3:
                            if (Checkb.IsChecked == true)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = TbPassword.Password;
                                Properties.Settings.Default.Save();
                            }
                            if (Checkb.IsChecked == false)
                            {
                                Properties.Settings.Default.Login = TbLogin.Text;
                                Properties.Settings.Default.Password = "";
                                Properties.Settings.Default.Save();
                            }
                            MessageBox.Show($"Добро пожаловать Админ {TbLogin.Text} ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppData.UserName = TbLogin.Text;
                            AppData.MainFrame.Navigate(new MenuAdm());
                            break;
                        default:
                            break;
                    }
                }
                else if (User == AppData.Context.Users.Where(p => p.Login == TbLogin.Text && p.Password != TbPassword.Password).FirstOrDefault())
                    MessageBox.Show("Не верный пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show($"Пользователя с Login'ом {TbLogin.Text} не существует", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void BtnRegistr_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegistrationPage());
        }

        private void Save()
        {
            if(Properties.Settings.Default.Password != string.Empty)
            {
                TbLogin.Text = Properties.Settings.Default.Login;
                TbPassword.Password = Properties.Settings.Default.Password;
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Password != string.Empty)
            {
                Save();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
