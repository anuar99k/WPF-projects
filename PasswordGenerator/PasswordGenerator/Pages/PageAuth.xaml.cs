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
    }
}
