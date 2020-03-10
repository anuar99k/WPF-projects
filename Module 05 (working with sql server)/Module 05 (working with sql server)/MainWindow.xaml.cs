using Module_05__working_with_sql_server_.Pages;
using System.Windows;

namespace Module_05__working_with_sql_server_
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

        private void MiEquipment_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new MainFormPage("equipment"));
        }

        private void MiManufacture_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new MainFormPage("manufacture"));
        }

        private void MiModel_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new MainFormPage("model"));
        }
    }
}
