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
using System.Windows.Shapes;

namespace AuthorizationMyWpf
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен быть не менее 5 символов!!";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                passBox.ToolTip = "Пароль должен быть не менее 5 символов!!";
                passBox.Background = Brushes.Red;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                //находим нужного пользователя в базе данных
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == password).FirstOrDefault();
                }
                if (authUser != null)
                {// при успешной авторизации перебрасываем  пользователя в его кабинет
                    MessageBox.Show("Пользователь зарегистрирован");
                    UserPersonalAcc userPersonalAcc = new UserPersonalAcc();
                    userPersonalAcc.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Неверный ввод");


            }
        }
        private void ButtonRegClick(object sender, RoutedEventArgs e)//переход на форму регистрации
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
