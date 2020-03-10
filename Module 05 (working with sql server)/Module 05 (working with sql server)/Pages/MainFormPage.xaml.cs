using Module_05_.BLL;
using Module_05_.DAL.Models;
using System.Windows.Controls;

namespace Module_05__working_with_sql_server_.Pages
{
    /// <summary>
    /// Interaction logic for MainFormPage.xaml
    /// </summary>
    public partial class MainFormPage : Page
    {
        public MainFormPage(string menuItemName)
        {
            InitializeComponent();

            switch (menuItemName)
            {
                case "equipment":
                    dataGrid.ItemsSource = DbLogic<Equipment>.GetAll();
                    break;
                case "manufacture":
                    dataGrid.ItemsSource = DbLogic<Manufacturer>.GetAll();
                    break;
                case "model":
                    dataGrid.ItemsSource = DbLogic<Model>.GetAll();
                    break;
            }
        }
    }
}
