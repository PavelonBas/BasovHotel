using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private bool number;
        private bool chr;
        private Clients clients;
        private Staff staff;
        private bool v;
        public RegistrationPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Roles.Select(p => p.Name).Distinct().ToList();
            CbRole.SelectedIndex = 1;
            CbRole.Visibility = Visibility.Collapsed;
            CbPosition.ItemsSource = AppData.Context.Positions.Select(p => p.Name_position).Distinct().ToList();
            CbPosition.Visibility = Visibility.Collapsed;
        }
        public RegistrationPage(Clients clients)
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Roles.Select(p => p.Name).Distinct().ToList();
            CbRole.SelectedIndex = 1;
            CbRole.Visibility = Visibility.Collapsed;
            CbPosition.ItemsSource = AppData.Context.Positions.Select(p => p.Name_position).Distinct().ToList();
            CbPosition.Visibility = Visibility.Collapsed;
            this.clients = clients;
            TbName.Text = clients.Name;
            TbSurName.Text = clients.SurName;
            TbPatronymic.Text = clients.Patronymic;
            TbAddress.Text = clients.Address;
            TbNumPass.Text = clients.Number_Passport.ToString();
            TbLogin.Text = AppData.Context.Users.Where(p=> p.id_User == clients.User_id).FirstOrDefault().Login.ToString();
            TbPassword.Text = AppData.Context.Users.Where(p => p.id_User == clients.User_id).FirstOrDefault().Password.ToString();
            BtReg.Content = "Редактировать";
            tbTop.Text = "Редактирование клиента";
        }
        public RegistrationPage(Staff staff)
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Roles.Select(p => p.Name).Distinct().ToList();
            CbRole.SelectedIndex = 2;
            CbRole.Visibility = Visibility.Collapsed;
            CbPosition.ItemsSource = AppData.Context.Positions.Select(p => p.Name_position).Distinct().ToList();
            dtP.Visibility = Visibility.Collapsed;
            this.staff = staff;
            v = true;
            TbName.Text = staff.Name;
            TbSurName.Text = staff.SurName;
            TbPatronymic.Text = staff.Patronymic;
            TbAddress.Text = staff.Address;
            TbNumPass.Text = staff.Number_Phone.ToString();
            TbLogin.Text = AppData.Context.Users.Where(p => p.id_User == clients.User_id).FirstOrDefault().Login.ToString();
            TbPassword.Text = AppData.Context.Users.Where(p => p.id_User == clients.User_id).FirstOrDefault().Password.ToString();
            BtReg.Content = "Редактировать";
            tbTop.Text = "Редактирование сотрудника";
            tbNum.Text = "Номер телефона";
        }

        public RegistrationPage(bool v)
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Roles.Select(p => p.Name).Distinct().ToList();
            CbRole.SelectedIndex = 2;
            CbRole.Visibility = Visibility.Collapsed;
            CbPosition.ItemsSource = AppData.Context.Positions.Select(p => p.Name_position).Distinct().ToList();
            dtP.Visibility = Visibility.Collapsed;
            this.v = v;
            tbNum.Text = "Номер телефона";
            BtReg.Content = "Добавление";
            tbTop.Text = "Добавление сотрудника";
        }
        
        public void Registr()
        {            
            if(v==true)
            {
                AppData.Context.Users.Add(
                   new Users()
                   {
                       Login = TbLogin.Text,
                       Password = TbPassword.Text,
                       Role = (CbRole.SelectedItem as Roles).id_Role
                   });
                AppData.Context.SaveChanges();
                AppData.Context.Staff.Add(new Staff()
                {
                    Name = TbName.Text,
                    SurName = TbSurName.Text,
                    Patronymic = TbPatronymic.Text,
                    Address = TbAddress.Text,
                    Code_Positions = (CbRole.SelectedItem as Positions).id_Codep,
                    Number_Phone = TbNumPass.Text,
                    User_id = AppData.Context.Users.Where(p => p.Login == TbLogin.Text).FirstOrDefault().id_User
                });
                AppData.Context.SaveChanges();
                MessageBox.Show($"Регистрация {TbLogin.Text} успешна", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                AppData.MainFrame.GoBack();
            }
            else 
            { 
               AppData.Context.Users.Add(
               new Users()
               {
                   Login = TbLogin.Text,
                   Password = TbPassword.Text,
                   Role = (CbRole.SelectedItem as Roles).id_Role
               });
                AppData.Context.SaveChanges();
                AppData.Context.Clients.Add(new Clients()
                {
                    Name = TbName.Text,
                    SurName = TbSurName.Text,
                    Patronymic = TbPatronymic.Text,
                    Address = TbAddress.Text,
                    Date_Of_Bithday = dtP.SelectedDate,
                    Number_Passport = Convert.ToInt32(TbNumPass.Text),
                    User_id = AppData.Context.Users.Where(p=>p.Login == TbLogin.Text).FirstOrDefault().id_User
                });
            AppData.Context.SaveChanges();
            MessageBox.Show($"Регистрация {TbLogin.Text} успешна", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            AppData.MainFrame.GoBack();
            }
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{1}[A-Za-z0-9._-]{0,}[A-Za-z0-9]{1}@\w{1,}\.\w{1,}$");
            if ((regex.IsMatch(TbPassword.Text) == false) || (regex.IsMatch(TbRePassword.Text) == false) || CbRole.SelectedIndex == -1 || (AppData.Context.Users.ToList().FirstOrDefault(p => p.Login == TbLogin.Text) != null) || (TbRePassword.Text != TbPassword.Text) || TbLogin.Text == "")
            {
                string error = "";
                if (TbLogin.Text == "")
                    error += "Логин пустой\n";
                if (TbRePassword.Text == "" || TbPassword.Text == "")
                {
                    if (TbPassword.Text == "")
                    {
                        error += "Введите пароль\n";
                    }
                    if (TbPassword.Text != "" || TbRePassword.Text == "")
                    {
                        error += "Повторите пароль\n";
                    }
                }
                else
                {
                    if (TbRePassword.Text != TbPassword.Text)
                        error += "Пароли не совпадают\n";
                }
                if (CbRole.SelectedIndex == -1)
                    error += "Выберете роль\n";
                if (number == false)
                    error += "Введите хотябы одну цифру\n";
                if (chr == false)
                    error += "Введите хотябы один спец-символ: !  ?  &  @  ;\n ";
                if (TbPassword.Text.Length <= 5 || TbPassword.Text.Length >= 13)
                    error += "Пароль не входит (в рамки от 6 до 12 символов)\n";
                if (AppData.Context.Users.ToList().FirstOrDefault(p => p.Login == TbLogin.Text) != null)
                    error += "Введённый Логин занят\n";
                var array = TbPassword.Text.ToArray();
                string buf = " ";
                foreach (var item in array)
                {
                    if (item == buf[0])
                    {
                        buf += item;
                    }
                    else
                    {
                        buf = item.ToString();
                    }
                    if (buf.Length == 3)
                    {
                        error += "Пароль имеет 3 символа подряд\n";
                    }
                }
                if (TbLogin.Text == TbPassword.Text)
                    error += "Логин и пароль совпадают\n";
                else if (TbLogin.Text == "" || TbRePassword.Text == "" || TbPassword.Text == "" || TbRePassword.Text != TbPassword.Text || number == false || chr == false || TbPassword.Text.Length <= 5 || TbPassword.Text.Length >= 13)
                {
                    MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Registr();
                }
            }
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == "" && TbPassword.Text == "" && CbRole.SelectedIndex == -1 && TbRePassword.Text == ""&&TbName.Text ==""&&TbSurName.Text==""&&TbPatronymic.Text=="" &&TbAddress.Text==""&&TbNumPass.Text=="")
            {
                MessageBox.Show($"Нечего очищать", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TbLogin.Text = "";
                TbPassword.Text = "";
                CbRole.SelectedIndex = -1;
                TbRePassword.Text = "";
                TbName.Text = "";
                TbPatronymic.Text = "";
                TbSurName.Text = "";
                TbAddress.Text = "";
                TbNumPass.Text = "";
            }
        }

        private void TbPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) number = true;
            if (e.Text == "@" || e.Text == "!" || e.Text == ";" || e.Text == "?" || e.Text == "&") chr = true;
        }

        private void TbNumPass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void CbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
