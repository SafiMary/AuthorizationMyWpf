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
using System.Data.SQLite;

namespace AuthorizationMyWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            //List<User> users = db.Users.ToList();// все записи будут преобразованы в формат списка
            //string str = "";
            //foreach (User user in users)
            
            //    str += "Login: " + user.Login + " | ";
            //ShowMessageblock.Text = str;
        }

        private void ButtonRegClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password1 = passBox1.Password.Trim();
            string password2 = passBox1.Password.Trim();
            string email  = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен быть не менее 5 символов!!";
                textBoxLogin.Background = Brushes.Red;
            }else if(password1.Length < 5)
            {
                passBox1.ToolTip = "Пароль должен быть не менее 5 символов!!";
                passBox1.Background = Brushes.Red;
            }
            else if (password1 != password2)
            {
                passBox2.ToolTip = "Пароли не совпадают!!";
                passBox2.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Неправильный ввод Email!!";
                textBoxEmail.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox1.ToolTip = "";
                passBox1.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                MessageBox.Show("Такой пользователь существует");
                
                User user = new User(login,password1,email);
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
                
        }
        private void ButtonEnterClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
