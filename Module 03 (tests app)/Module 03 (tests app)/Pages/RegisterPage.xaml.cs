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

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private DBcontext dB = new DBcontext();
        private User _user = new User();

        public RegisterPage()
        {
            InitializeComponent();
            spWrapper.DataContext = _user;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Login == "" || _user.Password == "" || _user.Login == null || _user.Password == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                List<User> allUsers = dB.GetAllUsers();
                foreach (User user in allUsers)
                {
                    if (user.Login == _user.Login)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }
                }
                if (dB.AddUser(_user))
                {
                    MessageBox.Show("Вы успешно зарегистрировались");
                    MainWindow.MainFrame_.Navigate(new LoginPage());
                }
                else
                {
                    MessageBox.Show("Регистрация не удалась");
                }
            }
        }
    }
}
