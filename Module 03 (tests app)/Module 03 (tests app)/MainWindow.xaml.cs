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
using Module_03__tests_app_.Pages;

namespace Module_03__tests_app_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame_ = null;
        public static MenuItem miMainMenu_ = null;

        public MainWindow()
        {
            InitializeComponent();

            MainFrame_ = mainFrame;

            MainFrame_.Navigate(new startPage());

            miMainMenu_ = miMainMenu;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame_.Navigate(new LoginPage());
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            MainFrame_.Navigate(new RegisterPage());
        }
    }
}
