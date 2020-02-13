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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        StringBuilder result = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            result.Clear();
            int pswrdSize = rnd.Next(6, 16);
            for (int i = 0; i < pswrdSize; i++)
            {
                result.Append(((char)rnd.Next(33, 126)).ToString());
            }
            tbxResultOfGen.Text = result.ToString();
        }
    }
}
