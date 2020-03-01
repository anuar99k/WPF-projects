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
using System.Xml.Serialization;

namespace Module_03__tests_app_.Pages
{
    /// <summary>
    /// Interaction logic for startPage.xaml
    /// </summary>
    public partial class startPage : Page
    {
        public startPage()
        {
            InitializeComponent();

            loadTests();
        }

        private List<Test> _tests = new List<Test>();

        private void loadTests()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Test>));

            if (new FileInfo("questions.xml").Length != 0)
            {
                using (FileStream fs = new FileStream("questions.xml", FileMode.Open))
                {
                    _tests = (List<Test>)formatter.Deserialize(fs);
                }
            }

            if (_tests.Count == 0)
            {
                lbTests.VerticalAlignment = VerticalAlignment.Center;
                lbTests.HorizontalAlignment = HorizontalAlignment.Center;
                Label lbl = new Label() { Content = "Тестов не найдено", FontSize = 16 };
                lbTests.Items.Add(lbl);
                return;
            }

            foreach (Test test in _tests)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                Grid gridWrapper = new Grid();

                gridWrapper.ColumnDefinitions.Add(new ColumnDefinition());
                gridWrapper.ColumnDefinitions.Add(new ColumnDefinition());
                gridWrapper.ColumnDefinitions.Add(new ColumnDefinition());
                gridWrapper.ColumnDefinitions.Add(new ColumnDefinition());

                Label lblTestName = new Label() { FontSize = 16 };
                Grid.SetColumn(lblTestName, 0);
                lblTestName.Content = test.nameOfSection;

                Label lblTestDescription = new Label() { FontSize = 16 };
                Grid.SetColumn(lblTestDescription, 1);
                lblTestDescription.Content = test.desription;

                Label lblTestAuthor = new Label() { FontSize = 16 };
                Grid.SetColumn(lblTestAuthor, 2);
                lblTestAuthor.Content = test.author;

                Button btnPassTest = new Button() { FontSize = 16, Padding = new Thickness(5, 3, 3, 5) };
                Grid.SetColumn(btnPassTest, 3);
                btnPassTest.Content = "пройти тест";
                btnPassTest.Click += (sender, e) => BtnPassTest_Click(sender, e, test);

                gridWrapper.Children.Add(lblTestName);
                gridWrapper.Children.Add(lblTestDescription);
                gridWrapper.Children.Add(lblTestAuthor);
                gridWrapper.Children.Add(btnPassTest);

                listBoxItem.Content = gridWrapper;

                lbTests.Items.Add(listBoxItem);
            }
        }

        private void BtnPassTest_Click(object sender, RoutedEventArgs e, Test test)
        {
            MainWindow.MainFrame_.Navigate(new TestPage(test));
        }
    }
}
