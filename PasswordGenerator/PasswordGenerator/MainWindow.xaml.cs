using PasswordGenerator.Pages;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        StringBuilder result = new StringBuilder();
        
        public static Frame AuthFrame_ = null;
        
        public MainWindow()
        {
            InitializeComponent();

            AuthFrame_ = authFrame;

            AuthFrame_.Navigate(new PageAuth());
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
