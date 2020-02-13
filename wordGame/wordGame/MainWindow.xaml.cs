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

namespace wordGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string[] words = new string[] { "компьютер", "книга", "ручка", "машина" };

        public MainWindow()
        {
            InitializeComponent();

            Random random = new Random();
            int randomNumber = random.Next(0, words.Length);
            string word = words[randomNumber];
            char[] hiphons = new char[word.Length + 1];
            for (int i = 0; i < word.Length + 1; i++)
            {
                hiphons[i] = '_';
            }
            lblMainWord.Content = string.Join("  ", hiphons) + "          Загадываемое слово: " + word;
            int numberOfAttemps = 15;
            lblNumberOfAttemps.Content = "Количество попыток: " + numberOfAttemps.ToString();
        }

        private void BtnCheckWord_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
