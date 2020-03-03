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

namespace Module_07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_1_GotFocus(object sender, RoutedEventArgs e)
        {
            button_1_1.Background = Brushes.MediumAquamarine;
        }

        private void Button_1_2_GotFocus(object sender, RoutedEventArgs e)
        {
            button_1_2.Background = Brushes.MediumAquamarine;
        }

        private void TextBlock_1_2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBlock_1_2.TextDecorations = null;
        }

        private void TextBlock_1_1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBlock_1_1.TextDecorations = null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            bgImage.ImageSource = new BitmapImage(new Uri(@"slide_1.jpg", UriKind.Relative));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            bgImage.ImageSource = new BitmapImage(new Uri(@"slide_2.jpg", UriKind.Relative));
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            bgImage.ImageSource = new BitmapImage(new Uri(@"slide_4.jpg", UriKind.Relative));
        }
    }
}
