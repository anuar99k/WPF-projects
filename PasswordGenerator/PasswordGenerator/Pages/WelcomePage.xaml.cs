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
using static PasswordGenerator.Pages.PageRegister;

namespace PasswordGenerator.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage(User user)
        {
            InitializeComponent();

            lblWelcome.FontSize = 16;
            lblWelcome.Content = "Добро пожаловать " + user.fullName;
        }
    }
}
