using System;
using System.Collections.Generic;
using System.IO;
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

namespace carBrands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loadButtons();
        }

        private void loadButtons()
        {
            string[] carBrands = Directory.GetFiles(@"Images", "*.png");
            foreach(string carBrand in carBrands)
            {
                Button btn = new Button() { Background = Brushes.Transparent, BorderThickness = new Thickness(0, 0, 0, 0) };
                StackPanel spBtnContent = new StackPanel() { Orientation = Orientation.Horizontal };
                Image img = new Image() { Width = 50, Height = 50 };
                img.Source = new BitmapImage(new Uri(carBrand, UriKind.Relative));
                TextBlock textOfBtn = new TextBlock();
                textOfBtn.VerticalAlignment = VerticalAlignment.Center;
                //textOfBtn.TextDecorations = 
                textOfBtn.Padding = new Thickness(5, 5, 5, 5);
                textOfBtn.FontSize = 16;
                textOfBtn.Text = carBrand.Split('\\')[1].Split('.')[0];
                spBtnContent.Children.Add(img);
                spBtnContent.Children.Add(textOfBtn);
                btn.Content = spBtnContent;
                buttonsWrapper.Children.Add(btn);
            }
        }
    }
}
