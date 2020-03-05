using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static PasswordGenerator.Pages.PageRegister;

namespace PasswordGenerator.Pages
{
    /// <summary>
    /// Interaction logic for PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public PageAuth()
        {
            InitializeComponent();
        }

        private void BtnRegistr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AuthFrame_.Navigate(new PageRegister());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            string password = psxPassword.Password;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            using (FileStream fs = new FileStream("usersInfo.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                string fileContent;
                using (StreamReader reader = new StreamReader(fs))
                {
                    fileContent = reader.ReadToEnd();
                }
                List<User> users = serializer.Deserialize<List<User>>(fileContent);

                bool isFound = false;
                User foundUser = null;
                if (users != null)
                {
                    foreach (User user in users)
                    {
                        if (user.Login == login)
                        {
                            if (MyCrypt.Decrypt(user.Password) == password)
                            {
                                isFound = true;
                                foundUser = user;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль");
                            }
                        }
                    }
                }
                if (isFound)
                    MainWindow.AuthFrame_.Navigate(new WelcomePage(foundUser));
                else
                    MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
