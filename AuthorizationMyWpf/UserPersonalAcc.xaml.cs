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
    /// Interaction logic for UserPersonalAcc.xaml
    /// </summary>
    public partial class UserPersonalAcc : Window
    {
        public UserPersonalAcc()
        {
            InitializeComponent();
            //обращаемся к базе, создаем список
            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList();
            listOfUsers.ItemsSource = users;
            // есть 2 зарег-анных пользователя, у каждого из них меняется цвет формы
            //login1 , login2 пароль 12345
            foreach (User user in users)
            {
                if(user.Login == "login1")
                {
                    MyGrid.Background = Brushes.Fuchsia;
                }
                if (user.Login == "login2")
                {
                    MyGrid.Background = Brushes.Aquamarine;
                }
            }
        }
    }
}
